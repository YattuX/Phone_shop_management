using Kada.Application.Contracts.Pesistence;
using Kada.persistence.DatabaseContext;
using Kada.persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Kada.persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KadaDataBaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("KadaConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IFournisseurRepository, FournisseurRepository>();
            services.AddScoped<ITypeArticleRepository, TypeArticleRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IStockageRepository, StockageRepository>();
            services.AddScoped<IParticulariteRepository, ParticulariteRepository>();
            services.AddScoped<IEtatRepository, EtatRepository>();
            services.AddScoped<ICouleurRepository, CouleurRepository>();
            services.AddScoped<IMarqueRepository, MarqueRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<ICaracteristiqueRepository, CaracteristiqueRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IReparationRepository, ReparationRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            return services;
        }
    }
}
