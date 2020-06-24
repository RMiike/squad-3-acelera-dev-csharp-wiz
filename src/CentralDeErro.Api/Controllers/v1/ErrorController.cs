using System;
using System.Collections.Generic;
using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.Api.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        //TODO Passar token via authorization
        //get: v1/testlog
        [HttpGet("testlog")]
        public IActionResult Get()
        {
            return Ok(new Error(1,"aposkdsop123","titulo","detalhe",DateTime.Now, 1,1,1,1));
        }

        //TODO adicionar query - apenas pelo token do usuário.
        //add mapper
        //get: v1/alllogs

        [HttpGet("alllogs")]
        [ResponseCache(Duration = 10)]
        public ActionResult<IEnumerable<Error>> Get([FromServices] IErrorRepository _errorRepository)
        {
            var allLogs = _errorRepository.Get();
            return Ok(allLogs);
        }

        // GET: v1/log/5
        [HttpGet("log/{id}", Name = "LogById")]
        public ActionResult<Error> Get([FromServices] IErrorRepository _errorRepository, int id)
        {
            var log = _errorRepository.Get(id);
            if (log != null)
            {
                return Ok(log);
            }
            return NotFound();
        }

        [HttpPost("addlog")]
        public ActionResult<Error> Post([FromServices] IErrorRepository _errorRepository, [FromHeader] string Authorization, Error logErro)
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
