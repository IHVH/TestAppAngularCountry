using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;

namespace EntitiesDAL.SQLite.Repositories
{
    public class ProvinceRepository : TestAppRepository<Province>, IProvinceRepository
    {
        private readonly AppSQLiteContext _db;

        public ProvinceRepository(AppSQLiteContext context) : base(context)
        {
            _db = context;
        }
    }
}