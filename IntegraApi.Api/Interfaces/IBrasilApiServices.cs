using IntegraApi.Api.Dtos;
using IntegraApi.Api.Models;

namespace IntegraApi.Api.Interfaces
{
    public interface IBrasilApiServices
    {
        Task<ResponseGeneric<EnderecoModel>> GetAdressByCEP(string cep);
        Task<ResponseGeneric<IEnumerable<BancoModel>>> GetAllBanco();
        Task<ResponseGeneric<BancoModel>> GetBanco(string cod);
    }
}
