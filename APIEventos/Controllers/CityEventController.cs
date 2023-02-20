using APIEventos.Filter;
using APIEventos.Service.Dto;
using APIEventos.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(ExcecaoGeralFilter))]
    public class CityEventController : ControllerBase
    {
        public ICityEventService _CityEventService;

        public CityEventController(ICityEventService CityEventService)
        {
            _CityEventService = CityEventService;
        }
        [HttpGet("consulta/titulo")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Consultar(string nome)
        {
            return Ok(_CityEventService.Consultar(nome));

        }
        [HttpGet("consulta/local/data")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultarLocalData(string local, DateTime data)
        {


            return Ok(_CityEventService.ConsultarLocalData(local, data));


        }
        [HttpGet("consulta/preco/data")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConsultaPrecoData(decimal minPrice, decimal maxPrice, DateTime data)
        {


            return Ok(_CityEventService.ConsultaPrecoData(minPrice, maxPrice, data));


        }
        [HttpPost("inserir")]

        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Inserir(CityEventDto cityEvent)
        {
            if (!await _CityEventService.Inserir(cityEvent))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Consultar), cityEvent);

        }
        [HttpPut("atualizar")]

        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarEvento(CityEventDto cityevent, int id)
        {
            if (!await _CityEventService.AtualizarEvento(cityevent, id))
            {
                return BadRequest();
            }

            return NoContent();

        }
        [HttpDelete("deletar")]

        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarEvento(int idEvent)
        {
            if (await _CityEventService.DeletarEvento(idEvent) == false)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}