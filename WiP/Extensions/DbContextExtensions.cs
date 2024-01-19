using Microsoft.EntityFrameworkCore;
using WiP.Infrastructure.Data.Context;

namespace WiP.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WiPContext>(x => x.UseMySql(config["ConnectionStrings:Connection"], ServerVersion.AutoDetect(config["ConnectionStrings:Connection"])));
            return services;
        }
    }
}
