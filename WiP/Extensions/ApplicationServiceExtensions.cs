using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiP.Core.Interfaces.Repositories;
using WiP.Core.Interfaces;
using WiP.Infrastructure.Data.Repository;
using WiP.Infrastructure;

namespace WiP.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            return services;
        }
    }
}
