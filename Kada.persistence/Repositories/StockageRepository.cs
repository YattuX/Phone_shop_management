using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class StockageRepository : GenericRepository<Stockage>, IStockageRepository
    {
        public StockageRepository(KadaDataBaseContext context) : base(context) { }
    }
}
