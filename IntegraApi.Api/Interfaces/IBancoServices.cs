using IntegraApi.Api.Dtos;

namespace IntegraApi.Api.Interfaces
{
    public interface IBancoServices
    {
        Task<ResponseGeneric<BancoResponse>> GetBanco(string banco);
        Task<ResponseGeneric<IEnumerable<BancoResponse>>> GetAllBanco();
    }
}
