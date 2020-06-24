
using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CentralDeErro.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogErroController : ControllerBase
    {
        //TODO Passar token via authorization
        //get: v1/testlog
        [HttpGet("testlog")]
        public IActionResult Get()
        {
            return Ok(new Error(22,"token", "teste", "detalhes", DateTime.Now, 1, 1, 1, 1));
        }

        //TODO adicionar query - apenas pelo token do usuário.
        //add mapper
        //get: v1/alllogs

        [HttpGet("alllogs")]
        [ResponseCache(Duration = 10)]
        public ActionResult<IEnumerable<Error>> Get([FromServices] ILogErroRepository _errorRepository)
        {
            var allLogs = _errorRepository.Get();
            return Ok(allLogs);
        }

        // GET: v1/log/5
        [HttpGet("log/{id}", Name = "LogById")]
        public ActionResult<Error> Get([FromServices] ILogErroRepository _errorRepository, int id)
        {
            var log = _errorRepository.Get(id);
            if (log != null)
            {
                return Ok(log);
            }
            return NotFound();
        }

        [HttpPost("addlog")]
        public ActionResult<Error> Post([FromServices] ILogErroRepository _errorRepository, [FromHeader] string Authorization, Error logErro)
        {
            _errorRepository.Create(logErro);
            _errorRepository.SaveChanges();
            return CreatedAtRoute(nameof(Get), new { Id = logErro.Title }, logErro);
        }

        // // TODO - set arquivado / delet?
        // [HttpPut("{id}")]
        // public ActionResult UpdateCommand(int id, LogErroDto logErro)
        // {
        //     var logErroById = _logErroRepository.GetLogById(id);

        //     if (logErroById == null)
        //     {
        //         return NotFound();
        //     }

        //     _mapper.Map(logErro, logErroById);

        //     _logErroRepository.UpdateLog(logErroById);
        //     _logErroRepository.SaveChanges();

        //     return NoContent();
        // }

        // //patch?

        // // DELETE: api/ApiWithActions/5
        // [HttpDelete("{id}")]
        // public ActionResult Delete(int id)
        // {
        //     var logErroById = _logErroRepository.GetLogById(id);
        //     if (logErroById == null)
        //     {
        //         return NotFound();
        //     }

        //     _logErroRepository.DeleteLog(logErroById);
        //     _logErroRepository.SaveChanges();

        //     return Ok("Deletado com sucesso.");
        // }
    }
}
