using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Business.Profiles;
using Business.Services;
using Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection AddBusines(this IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddAutoMapper(options =>
            {
                //options.ConstructServicesUsing(c => environment);
                options.AddProfile(new PortfolioProfiles(environment));
                //options.AddMaps(typeof(PortfolioService).Assembly);
            });

            services.AddScoped<IPortfolioService, PortfolioService>();

            return services;
        }


    }
}
