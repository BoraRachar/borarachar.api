using BoraRachar.Domain.Entity.Users;

namespace BoraRachar.Domain.Entity.Bases;

public class PaginatedUserEntity
{
    public PaginatedMetaDataEntity MetaData { get; set; }
    public IEnumerable<User> Items { get; set; }
}
