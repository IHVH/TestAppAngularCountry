using EntitiesDAL.Models;
using EntitiesDAL.PostgreSQL;
using EntitiesDAL.PostgreSQL.Extensions;
using EntitiesDAL.SQLite;
using EntitiesDAL.SQLite.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestAppAngularCountry.Server.Configuration;
using TestAppAngularCountry.Server.Exceptions;

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
            ConnectionOptions connectionOptions = GetConnectionOptions(builder);
            if (!string.IsNullOrWhiteSpace(connectionOptions.PostgreSQL))
            {
                builder.Services.AddDbContext<AppPostgreSQLContext>(
                options => options.UseNpgsql(connectionOptions.PostgreSQL,
                optionsAction =>
                {
                    var assemblyName = typeof(AppPostgreSQLContext).GetTypeInfo().Assembly.GetName().Name;
                    optionsAction.MigrationsAssembly(assemblyName);
                }));
                builder.Services.AddPostgreSQLRepositories();
            }
            else if (!string.IsNullOrWhiteSpace(connectionOptions.SQLite))
            {
                builder.Services.AddDbContext<AppSQLiteContext>(
                options => options.UseSqlite(connectionOptions.SQLite,
                optionsAction =>
                {
                    var assemblyName = typeof(AppSQLiteContext).GetTypeInfo().Assembly.GetName().Name;
                    optionsAction.MigrationsAssembly(assemblyName);
                }));
                builder.Services.AddSQLiteRepositories();
            }
            else
            {
                throw new ConfigurationMissingException("You must specify a database connection string!");
            }

        }

        public static void AddIdentity(this WebApplicationBuilder builder)
        {
            ConnectionOptions connectionOptions = GetConnectionOptions(builder);
            if (!string.IsNullOrWhiteSpace(connectionOptions.PostgreSQL))
            {
                builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppPostgreSQLContext>();
            }
            else if (!string.IsNullOrWhiteSpace(connectionOptions.SQLite))
            {
                builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppSQLiteContext>();
            }
            else
            {
                throw new ConfigurationMissingException("You must specify a database connection string!");
            }

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequiredUniqueChars = 1;

                options.User.RequireUniqueEmail = true;
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        private static ConnectionOptions GetConnectionOptions(WebApplicationBuilder builder)
        {
            ConnectionOptions connectionOptions = new();
            builder.Configuration.GetSection(ConnectionOptions.ConnectionStrings).Bind(connectionOptions);
            return connectionOptions;
        }
    }
}
