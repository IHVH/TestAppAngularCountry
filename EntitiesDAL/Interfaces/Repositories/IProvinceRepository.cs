using EntitiesDAL.Models;

namespace EntitiesDAL.Interfaces.Repositories
{
    public interface IProvinceRepository : ITestAppRepository<Province>
    {
        Task<List<Province>> GetListProvinceAsNoTracking(int countryId);
    }
}
