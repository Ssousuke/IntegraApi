using IntegraApi.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;

namespace IntegraApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        public readonly IEnderecoServices _enderecoServices;
        public EnderecoController(IEnderecoServices enderecoServices)
        {
            _enderecoServices = enderecoServices;
        }

        [HttpGet("buscar/{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddress([FromRoute] string cep)
        {
            var response = await _enderecoServices.GetAdressByCEP(cep);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.ResponseData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReturnError);
            }
        }
    }
}
