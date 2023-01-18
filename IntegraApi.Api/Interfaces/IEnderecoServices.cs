using IntegraApi.Api.Dtos;
using IntegraApi.Api.Models;

namespace IntegraApi.Api.Interfaces
{
    public interface IEnderecoServices
    {
        Task<ResponseGeneric<EnderecoResponse>> GetAdressByCEP(string cep);
    }
}
