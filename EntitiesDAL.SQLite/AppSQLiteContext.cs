using Microsoft.EntityFrameworkCore;

namespace EntitiesDAL.SQLite
{
    public class AppSQLiteContext : AppContext
    {
        public AppSQLiteContext(DbContextOptions<AppSQLiteContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}