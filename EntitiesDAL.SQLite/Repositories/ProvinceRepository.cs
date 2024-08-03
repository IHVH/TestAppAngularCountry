using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using EntitiesDAL.Repositories;

namespace EntitiesDAL.SQLite.Repositories
{
    public class ProvinceRepository : ProvinceRepositoryBase, IProvinceRepository
    {
        private readonly AppSQLiteContext _db;

        public ProvinceRepository(AppSQLiteContext context) : base(context)
        {
            _db = context;
        }
    }
}