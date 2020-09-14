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

        // GET: api/dataquad/GetAllRaces
        [HttpGet]
        public IActionResult GetAllRaces()
        {
            var ret = _service.sample();
            return Ok(ret);
        }

        // GET: api/dataquad/Sample
        [HttpGet]
        public IActionResult Sample()
        {
            return Ok(_service.sample());
        }

        // GET: api/dataquad/sampleget/?i=3
        // http://localhost:62045/api/dataquad/sampleget/?i=2
        [HttpGet]
        public IActionResult SampleGet(int i = 1)
        {
            return Ok(i);
        }
    }
}