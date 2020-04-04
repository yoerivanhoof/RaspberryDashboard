using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaspberryDashboard_Backend.Services;

namespace RaspberryDashboard_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MqttController : ControllerBase
    {
        private readonly IMqttService _mqttService;
        public MqttController(IMqttService mqttService)
        {
            _mqttService = mqttService;

        }
        // GET: api/Mqtt
        [HttpGet]
        public ActionResult Get()
        {
            _mqttService.PublishMessage("cmnd/tasmota/power", "toggle");
            return Ok("Yo");
        }

        // GET: api/Mqtt/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mqtt
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Mqtt/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
