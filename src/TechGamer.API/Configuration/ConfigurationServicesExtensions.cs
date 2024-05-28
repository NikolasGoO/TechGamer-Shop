using Microsoft.EntityFrameworkCore;
using TechGamer.Infra.Data.Context;
using TechGamer.Infra.Identity.Data;

namespace TechGamer.API.Configuration
{
    public static class ConfigurationServicesExtensions
    {
        public static IServiceCollection DbContextConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TechGamerDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer(connectionString));

            services.AddDistributedMemoryCache();

            return services;
        }
    }
}
