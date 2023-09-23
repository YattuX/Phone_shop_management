using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Model.Command.CreateModel;
using Kada.Application.Feature.Model.Command.UpdateModel;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class ModelProfile: Profile
    {
        public ModelProfile() 
        {
            CreateMap<ModelDTO, Model>().ReverseMap();
            CreateMap<CreateModelCommand, Model>().ReverseMap();
            CreateMap<UpdateModelCommand, Model>().ReverseMap();
        }
    }
}
