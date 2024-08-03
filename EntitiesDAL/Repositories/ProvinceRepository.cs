using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EntitiesDAL.Repositories
{
    public abstract class ProvinceRepositoryBase : TestAppRepository<Province>, IProvinceRepository
    {
        private readonly AppContext _db;

        protected ProvinceRepositoryBase(AppContext context) : base(context)
        {
            _db = context;
        }

        public virtual async Task<List<Province>> GetListProvinceAsNoTracking(int countryId)
        {
            return await _db.Provinces.AsNoTracking().Where(p => p.CountryId == countryId).ToListAsync();
        }
    }
}
