//using CatalystCMS.BAL.Services;
//using CatalystCMS.DAL.Repositories;
using CatalystCMS.BAL;
using CatalystCMS.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace CatalystCMS
{
    public static class ServiceExtensions
    {
        public static void RegisterRepos(this IServiceCollection collection, ConfigurationManager configuration)
        {
            var connectionString = configuration["ConnectionStrings:catalystCMS_DB_Connection"];

            collection.AddTransient<ILoginService, LoginService>();
            collection.AddTransient<IUserDetailsRepo>(s => new UserDetailsRepo(connectionString));

        }

    }
}
