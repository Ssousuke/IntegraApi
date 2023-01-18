using AutoMapper;
using IntegraApi.Api.Dtos;
using IntegraApi.Api.Interfaces;

namespace IntegraApi.Api.Services
{
    public class EnderecoServices : IEnderecoServices
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApiServices _brasilApiServices;

        public EnderecoServices(IMapper mapper, IBrasilApiServices brasilApiServices)
        {
            _mapper = mapper;
            _brasilApiServices = brasilApiServices;
        }
        public async Task<ResponseGeneric<EnderecoResponse>> GetAdressByCEP(string cep)
        {
            var endereco = await _brasilApiServices.GetAdressByCEP(cep);
            return _mapper.Map<ResponseGeneric<EnderecoResponse>>(endereco);
        }
    }
}
