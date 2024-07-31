using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;

namespace EntitiesDAL.PostgreSQL.Repositories
{
    public class ProvinceRepository : TestAppRepository<Province>, IProvinceRepository
    {
        private readonly AppPostgreSQLContext _db;

        public ProvinceRepository(AppPostgreSQLContext context) : base(context)
        {
            _db = context;
        }
    }
}