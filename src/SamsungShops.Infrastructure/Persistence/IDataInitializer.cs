using SamsungShops.Domain.IdentityEntities;

namespace SamsungShops.Infrastructure.Persistence
{
    public interface IDataInitializer
    {
        List<ApplicationRole> GetInitialRoles();
    }
}
