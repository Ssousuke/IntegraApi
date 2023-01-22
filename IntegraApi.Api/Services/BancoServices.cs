using AutoMapper;
using IntegraApi.Api.Dtos;
using IntegraApi.Api.Interfaces;
using System.Collections.Generic;

namespace IntegraApi.Api.Services
{
    public class BancoServices : IBancoServices
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApiServices _brasilApiServices;

        public BancoServices(IMapper mapper, IBrasilApiServices brasilApiServices)
        {
            _mapper = mapper;
            _brasilApiServices = brasilApiServices;
        }
        public async Task<ResponseGeneric<IEnumerable<BancoResponse>>> GetAllBanco()
        {
            var bancos = await _brasilApiServices.GetAllBanco();
            return _mapper.Map<ResponseGeneric<IEnumerable<BancoResponse>>>(bancos);
        }

        public async Task<ResponseGeneric<BancoResponse>> GetBanco(string nomeBanco)
        {
            var banco = await _brasilApiServices.GetBanco(nomeBanco);
            return _mapper.Map<ResponseGeneric<BancoResponse>>(banco);
        }
    }
}
