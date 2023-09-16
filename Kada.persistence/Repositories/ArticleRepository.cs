using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.persistence.Repositories
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(KadaDataBaseContext context):base(context) { }
    }
}
