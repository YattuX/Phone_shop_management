using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class ParticulariteRepository : GenericRepository<Particularite>, IParticulariteRepository
    {
        public ParticulariteRepository(KadaDataBaseContext context) : base(context) { }
    }
}
