using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralDeErro.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace CentralDeErro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogErroController : ControllerBase
    {
        private readonly ILogErroService _logErroService;

        public LogErroController(ILogErroService logErroService)
        {
            _logErroService = logErroService;
        }
        // GET: api/LogErro
        [HttpGet]
        public ActionResult<IEnumerable<LogErro>>  GetAllLog()
        {

            var logs = _logErroService.GetAllLogs();
            return Ok(logs);
        }

        // GET: api/LogErro/5
        [HttpGet("{id}", Name = "GetLogById")]
        public ActionResult<LogErro> GetLogById(int id)
        {
            var log = _logErroService.GetLogById(id);
            return Ok(log);
        }

        //// POST: api/LogErro
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/LogErro/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
