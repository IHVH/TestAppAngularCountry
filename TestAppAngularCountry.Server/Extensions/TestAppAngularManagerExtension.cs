using EntitiesDAL.Models;
using EntitiesDAL.PostgreSQL;
using EntitiesDAL.PostgreSQL.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestAppAngularCountry.Server.Configuration;

namespace TestAppAngularCountry.Server.Extensions
{
    public static class TestAppAngularManagerExtension
    {
        public static void AddAppLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
        }

        public static void AddAppDataBase(this WebApplicationBuilder builder)
        {
            ConnectionOptions connectionOptions = new();
            builder.Configuration.GetSection(ConnectionOptions.ConnectionStrings).Bind(connectionOptions);
            builder.Services.AddDbContext<AppPostgreSQLContext>(
                options => options.UseNpgsql(connectionOptions.ConnectionString,
                npgsqlOptionsAction => {
                    var assemblyName = typeof(AppPostgreSQLContext).GetTypeInfo().Assembly.GetName().Name;
                    npgsqlOptionsAction.MigrationsAssembly(assemblyName); 
                }));
            builder.Services.AddAppRepositories();
        }

        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppPostgreSQLContext>();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
            });
        }
    }
}
