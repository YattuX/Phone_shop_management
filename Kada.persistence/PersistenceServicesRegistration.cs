﻿using Kada.Application.Contracts.Pesistence;
using Kada.persistence.DatabaseContext;
using Kada.persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Kada.persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
       IConfiguration configuration)
        {
            services.AddDbContext<KadaDataBaseContext>(options => {
                options.UseSqlServer(configuration?.GetConnectionString("KadaConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
