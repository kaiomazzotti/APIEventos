using APIEventos.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
       private ICityEventService _cityEventService;
        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}