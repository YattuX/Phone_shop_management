using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;

namespace Kada.persistence.Repositories
{
    public class TypeArticleRepository:GenericRepository<TypeArticle>,ITypeArticleRepository
    {
        public TypeArticleRepository(KadaDataBaseContext context):base(context) { }
    }
}
