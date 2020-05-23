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
            var dateTime = DateTime.Now;

            var dateTimeFormatted = new DateTimeFormatted
            {
                day = dateTime.Day,
                month = dateTime.Month,
                year = dateTime.Year,
                hour = dateTime.Hour,
                minute = dateTime.Minute,
                second = dateTime.Second
            };

            return JsonSerializer.Serialize(dateTimeFormatted);
        }
    }
}
