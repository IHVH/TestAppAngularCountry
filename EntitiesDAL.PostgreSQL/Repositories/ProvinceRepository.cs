using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Repositories;

namespace EntitiesDAL.PostgreSQL.Repositories
{
    public class ProvinceRepository : ProvinceRepositoryBase, IProvinceRepository
    {
        private readonly AppPostgreSQLContext _db;

        public ProvinceRepository(AppPostgreSQLContext context) : base(context)
        {
            _db = context;
        }
    }
}