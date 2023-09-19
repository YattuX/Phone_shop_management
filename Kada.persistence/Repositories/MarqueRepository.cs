using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class MarqueRepository : GenericRepository<Marque>, IMarqueRepository
    {
        public MarqueRepository(KadaDataBaseContext context) : base(context) { }
    }
}
