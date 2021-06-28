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
    public class ServiceLifetimeController : ControllerBase
    {
        public ServiceLifetimeController(IServiceMarkerOne serOne,IServiceMarkerTwo serTwo)
        {
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
