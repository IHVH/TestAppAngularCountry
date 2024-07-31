using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;

namespace EntitiesDAL.PostgreSQL.Repositories
{
    public class CountryRepository : TestAppRepository<Country>, ICountryRepository
    {
        private readonly AppPostgreSQLContext _db;

        public CountryRepository(AppPostgreSQLContext context) : base(context)
        {
            _db = context;
        }
    }
}