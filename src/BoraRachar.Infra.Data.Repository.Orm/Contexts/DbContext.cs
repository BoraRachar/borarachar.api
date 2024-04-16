using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using BoraRachar.Domain.Entity.Bases;
using BoraRachar.Domain.Repository.Orm.Abstract.Contexts;

namespace BoraRachar.Infra.Data.Repository.Orm.Contexts;

[ExcludeFromCodeCoverage]
public class DbContext : Microsoft.EntityFrameworkCore.DbContext, IDbContext
{
    public new DbSet<T> Set<T>() where T : BaseEntity => base.Set<T>();

    public new EntityState Entry<T>(T entity) where T : BaseEntity =>
        base.Entry(entity).State = EntityState.Modified;

    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (Debugger.IsAttached)
            optionsBuilder.LogTo(l =>
            {
                Console.WriteLine(l);
                Debug.WriteLine(l);
            });
    }

    public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default) => base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var typesConfiguration = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Any(gi =>
                gi.IsGenericType &&
                gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
            .ToList();


        foreach (var configurationInstance in typesConfiguration.Select(Activator.CreateInstance))
            modelBuilder.ApplyConfiguration((dynamic)configurationInstance!);

        var strings = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(string));

        foreach (var property in strings)
        {
            if (property.GetMaxLength() == null)
                property.SetMaxLength(200);
        }
    }

    Task IDbContext.SaveChangesAsync(CancellationToken cancellationToken) => base.SaveChangesAsync(cancellationToken);
}