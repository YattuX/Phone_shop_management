﻿using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.persistence.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        public StockRepository(KadaDataBaseContext context) : base(context)
        {
        }
    }
}
