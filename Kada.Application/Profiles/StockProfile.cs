using AutoMapper;
using Kada.Application.Feature.Stock.Command.AddStock;
using Kada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<AddStockCommand, Stock>().ReverseMap();
        }
    }
}
