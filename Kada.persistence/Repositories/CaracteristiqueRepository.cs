using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class CaracteristiqueRepository : GenericRepository<Caracteristique>, ICaracteristiqueRepository
    {
        public CaracteristiqueRepository(KadaDataBaseContext context) : base(context) { }
    }
}
