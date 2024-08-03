using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using EntitiesDAL.Repositories;

namespace EntitiesDAL.SQLite.Repositories
{
    public class UserRepository : TestAppRepository<User>, IUserRepository
    {
        private readonly AppSQLiteContext _db;

        public UserRepository(AppSQLiteContext context) : base(context)
        {
            _db = context;
        }
    }
}