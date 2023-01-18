using IntegraApi.Api.Dtos;
using IntegraApi.Api.Interfaces;
using IntegraApi.Api.Models;
using System.Dynamic;
using System.Net.Http;
using System.Text.Json;

namespace IntegraApi.Api.Rest
{
    public class BrasilApiRest : IBrasilApiServices
    {
        public async Task<ResponseGeneric<EnderecoModel>> GetAdressByCEP(string cep)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            ResponseGeneric<EnderecoModel> response = new ResponseGeneric<EnderecoModel>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseBrasilApi = await client.SendAsync(request);
                string contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                EnderecoModel? json = JsonSerializer.Deserialize<EnderecoModel>(contentResponse);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.StatusCode = responseBrasilApi.StatusCode;
                    response.ResponseData = json;
                }
                else
                {
                    response.StatusCode = responseBrasilApi.StatusCode;
                    response.ReturnError = JsonSerializer.Deserialize<ExpandoObject>(contentResponse);
                }
            }
            return response;
        }

        public Task<ResponseGeneric<List<BancoModel>>> GetAllBanco()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseGeneric<BancoModel>> GetBanco(string cod)
        {
            throw new NotImplementedException();
        }
    }
}
