using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class TypeRepository : GenericRepository<Type_>, ITypeRepository
    {
        public TypeRepository(KadaDataBaseContext context ):base(context) { }
    }
}
