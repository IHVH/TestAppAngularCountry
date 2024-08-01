using Microsoft.EntityFrameworkCore;

namespace EntitiesDAL.PostgreSQL
{
    public class AppPostgreSQLContext : AppContext
    {
        public AppPostgreSQLContext(DbContextOptions<AppPostgreSQLContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
