using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Client_.Command.CreateClient;
using Kada.Application.Feature.Client_.Command.UpdateClient;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile() 
        {
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<CreateClientCommand, Client>().ReverseMap();
            CreateMap<UpdateClientCommand, Client>().ReverseMap();

           
        }

    }
}
