using IntegraApi.Api.Dtos;
using IntegraApi.Api.Interfaces;
using IntegraApi.Api.Models;
using System.Dynamic;
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

        public async Task<ResponseGeneric<IEnumerable<BancoModel>>> GetAllBanco()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://brasilapi.com.br/api/banks/v1");
            ResponseGeneric<IEnumerable<BancoModel>> response = new ResponseGeneric<IEnumerable<BancoModel>>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseBrasilApi = await client.SendAsync(request);
                string contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                IEnumerable<BancoModel>? json = JsonSerializer.Deserialize<IEnumerable<BancoModel>>(contentResponse);

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

        public async Task<ResponseGeneric<BancoModel>> GetBanco(string cod)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{cod}");
            ResponseGeneric<BancoModel> response = new ResponseGeneric<BancoModel>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage responseBrasilApi = await client.SendAsync(request);
                string contentResponse = await responseBrasilApi.Content.ReadAsStringAsync();
                BancoModel? json = JsonSerializer.Deserialize<BancoModel>(contentResponse);

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
    }
}
