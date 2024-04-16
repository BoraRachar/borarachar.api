using BoraRachar.Api.Filters;
using BoraRachar.Infra.Bootstrap.AutoMapper;
using BoraRachar.Infra.Bootstrap.Configuration;
using BoraRachar.Infra.Bootstrap.Database;
using BoraRachar.Infra.Bootstrap.Hangfire;
using BoraRachar.Infra.Bootstrap.MediatR;
using BoraRachar.Infra.Bootstrap.Service;
using BoraRachar.Infra.Bootstrap.Swagger;
using BoraRachar.Infra.Bootstrap.Validation;
using BoraRachar.Infra.Bootstrap.Version;

var applicationName = "BoraRachar";
var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddCustomAutoMapper()
    .AddCustomMediatR()
    .AddServices()
    .AddRepositories(builder.Configuration)
    .AddHangfire(builder.Configuration)
    .AddVersion()
    .AddValidation()
    .AddSwaggerApi<RemoveQueryApiVersionParamOperationFilter, RemoveDefaultApiVersionRouteDocumentFilter>(applicationName)
    .AddCustomConfiguration(typeof(ValidatorFilter))
    .AddCors(options =>
     {
         options.AddPolicy(name: "CorsPolicy",
            policy =>
            {
                policy.WithOrigins("*")
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
     });

var app = builder.Build();
app.UseCors("CorsPolicy");
app.UseDefaultConfigure(app.Environment, applicationName);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();