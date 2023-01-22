using AutoMapper;
using IntegraApi.Api.Dtos;
using IntegraApi.Api.Models;

namespace IntegraApi.Api.Mappings
{
    public class BancoMapping : Profile
    {
        public BancoMapping()
        {
            CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));
            CreateMap<BancoResponse, BancoModel>().ReverseMap();
        }
    }
}
