using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class EtatRepository: GenericRepository<Etat>,IEtatRepository
    {
        public EtatRepository(KadaDataBaseContext context) : base(context) { }
    }
}
