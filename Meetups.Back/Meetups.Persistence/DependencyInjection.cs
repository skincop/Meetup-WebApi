using Meetups.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MeetupsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IMeetupsDbContext>(provider =>
                provider.GetService<MeetupsDbContext>());
            return services;
        }
    }
}
