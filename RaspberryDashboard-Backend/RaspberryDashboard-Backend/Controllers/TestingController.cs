using System;
using Microsoft.AspNetCore.Mvc;

namespace RaspberryDashboard_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            Console.WriteLine("get called");
            return "hi";
        }
    }
}