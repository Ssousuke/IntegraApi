
using IntegraApi.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace IntegraApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        public readonly IBancoServices _services;

        public BancoController(IBancoServices services)
        {
            _services = services;
        }

        [HttpGet("buscar/todos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBancos()
        {
            var response = await _services.GetAllBanco();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.ResponseData);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.ReturnError);
            }
        }

        [HttpGet("buscar/{cod}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBanco([RegularExpression("^[0-9]*$")] string cod)
        {
            var response = await _services.GetBanco(cod);
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
