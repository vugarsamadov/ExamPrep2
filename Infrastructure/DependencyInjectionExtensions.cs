using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>()
                .AddIdentityCore<IdentityUser>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }

    }
}
