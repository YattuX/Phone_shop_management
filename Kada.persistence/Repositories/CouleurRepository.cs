using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class CouleurRepository : GenericRepository<Couleur>, ICouleurRepository
    {
        public CouleurRepository(KadaDataBaseContext context) : base(context) { }
    }
}
