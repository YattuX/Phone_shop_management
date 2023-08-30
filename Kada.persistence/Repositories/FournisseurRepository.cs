using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class FournisseurRepository : GenericRepository<Fournisseur>, IFournisseurRepository
    {
        public FournisseurRepository(KadaDataBaseContext context) : base(context)
        {
        }
    }
}
