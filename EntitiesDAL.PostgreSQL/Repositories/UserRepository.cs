using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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