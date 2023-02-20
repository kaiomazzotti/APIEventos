using APIEventos.Service.Dto;
using APIEventos.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APIEventos.Controllers
{


    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        public IEventReservationService _EventReservationService;

        public EventReservationController(IEventReservationService CityEventService)
        {
            _EventReservationService = CityEventService;
        }


        [HttpPost("Inserir")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Inserir(EventReservationDto eventReservation)
        {
            if (!await _EventReservationService.Inserir(eventReservation) == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(ConsultaPersonTitle), eventReservation);
        }
        [HttpPut("Atualizar")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditarQuantidade(int numero, long idReservation)
        {
            if (!await _EventReservationService.EditarQuantidade(numero, idReservation))
            {
                return BadRequest();
            }

            return NoContent();

        }
        [HttpGet("Consulta")]
       
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<EventReservationDto>>> ConsultaPersonTitle(string nome, string tituloEvento)
        {

            return Ok(await _EventReservationService.ConsultaPersonTitle(nome, tituloEvento));
        }
        [HttpDelete("Deletar")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletarReserva(long idReservation)
        {
            if (_EventReservationService.DeletarReserva(idReservation) == null)
            {
                return BadRequest();
            }

            return Ok(_EventReservationService.DeletarReserva(idReservation));
        }
    }
}
