using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using EntitiesDAL.Repositories;

namespace EntitiesDAL.SQLite.Repositories
{
    public class CountryRepository : TestAppRepository<Country>, ICountryRepository
    {
        private readonly AppSQLiteContext _db;

        public CountryRepository(AppSQLiteContext context) : base(context)
        {
            _db = context;
        }
    }
}