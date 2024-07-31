using EntitiesDAL.Interfaces.Repositories;
using EntitiesDAL.PostgreSQL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EntitiesDAL.PostgreSQL.Extensions
{
    public static class RepoPostgreManagerExtension
    {
        public static void AddAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
        }
    }
}