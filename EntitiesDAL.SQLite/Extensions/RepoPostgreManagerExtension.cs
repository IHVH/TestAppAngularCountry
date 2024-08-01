using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.SQLite.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EntitiesDAL.SQLite.Extensions
{
    public static class RepoSQLiteManagerExtension
    {
        public static void AddSQLiteRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
        }
    }
}