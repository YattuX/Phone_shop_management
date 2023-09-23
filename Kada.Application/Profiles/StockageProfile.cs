using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Stockage.Command.CreateStockage;
using Kada.Application.Feature.Stockage.Command.UpdateStockage;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class StockageProfile : Profile
    {
        public StockageProfile() 
        {
            CreateMap<StockageDTO, Stockage>().ReverseMap();
            CreateMap<CreateStockageCommand, Stockage>().ReverseMap();
            CreateMap<UpdateStockageCommand, Stockage>().ReverseMap();
        }
    }
}
