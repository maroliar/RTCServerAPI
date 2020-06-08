using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RTCServerAPI.Entities;

namespace RTCServerAPI.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class RTCController : ControllerBase
    {
        private readonly ILogger<RTCController> _logger;

        public RTCController(ILogger<RTCController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content(GetAndFormatJsonDateTime());
        }

        private string GetAndFormatJsonDateTime()
        {
            //var dateTimeFormatted = 
            //    DateTime.Now.ToShortDateString()
            //    + " - " + 
            //    DateTime.Now.ToLongTimeString();

            var dateTimeFormatted = new DateTimeFormatted
            {
                date = DateTime.Now.ToShortDateString(),
                time = DateTime.Now.ToLongTimeString(),
            };

            return JsonSerializer.Serialize(dateTimeFormatted);
            //return dateTimeFormatted;
        }
    }
}
