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
        public ServiceLifetimeController(IServiceMarkerOne serOne,IServiceMarkerTwo serTwo,IEnumerable<ISingletonObject> enumSingObjects)
        {
            SerOne = serOne;
            SerTwo = serTwo;
            EnumSingObjects = enumSingObjects;
        }

        public IServiceMarkerOne SerOne { get; }
        public IServiceMarkerTwo SerTwo { get; }
        //IEnumerable stores each ISingletonObject injections which is in Startup.cs / ConfigurationServices.
        public IEnumerable<ISingletonObject> EnumSingObjects { get; }

        [HttpGet]
        public IActionResult Get()
        {
            SerOne.PrintConsole();
            SerTwo.PrintConsole();

            Console.WriteLine("IEnumerable<ISingletonObject>() Instance.Id");
            foreach (var instance in EnumSingObjects)
            {
                Console.WriteLine(instance.Id);
            }

            return Ok("Check out your debug console to see the output");
        }
    }
}
