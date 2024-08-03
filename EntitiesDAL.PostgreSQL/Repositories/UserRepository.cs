using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using EntitiesDAL.Repositories;

namespace EntitiesDAL.PostgreSQL.Repositories
{
    public class UserRepository : TestAppRepository<User>, IUserRepository
    {
        private readonly AppPostgreSQLContext _db;

        public UserRepository(AppPostgreSQLContext context) : base(context)
        {
            _db = context;
        }
    }
}