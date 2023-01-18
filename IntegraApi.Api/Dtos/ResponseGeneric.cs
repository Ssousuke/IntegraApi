using System.Dynamic;
using System.Net;

namespace IntegraApi.Api.Dtos;

public class ResponseGeneric<T> where T : class
{
    public HttpStatusCode StatusCode { get; set; }
    public T? ResponseData { get; set; }
    public ExpandoObject? ReturnError { get; set; }
}
