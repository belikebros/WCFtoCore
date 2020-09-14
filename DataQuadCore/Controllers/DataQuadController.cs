using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WCFService;

namespace DataQuadCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DataQuadController : ControllerBase
    {
        private IDataQuadService _service;

        public DataQuadController(IDataQuadService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllRaces()
        {
            var ret = _service.sample();
            return Ok(ret);
        }
        [HttpGet]
        public IActionResult Sample()
        {
            return Ok(_service.sample());
        }
    }
}