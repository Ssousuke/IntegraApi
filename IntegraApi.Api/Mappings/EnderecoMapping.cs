using AutoMapper;
using IntegraApi.Api.Dtos;
using IntegraApi.Api.Models;

namespace IntegraApi.Api.Mappings
{
    public class EnderecoMapping : Profile
    {
        public EnderecoMapping()
        {
            CreateMap(typeof(ResponseGeneric<>), typeof(ResponseGeneric<>));
            CreateMap<EnderecoResponse, EnderecoModel>().ReverseMap();
        }
    }
}
