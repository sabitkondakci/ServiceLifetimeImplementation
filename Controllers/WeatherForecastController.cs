using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceLifetime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IServiceMarkerOne serOne,IServiceMarkerTwo serTwo)
        {
            _logger = logger;
            SerOne = serOne;
            SerTwo = serTwo;
        }

        public IServiceMarkerOne SerOne { get; }
        public IServiceMarkerTwo SerTwo { get; }

        [HttpGet]
        public IActionResult Get()
        {
            SerOne.PrintConsole();
            SerTwo.PrintConsole();
            return Ok("Check out your debug console to see the output");
        }
    }
}
