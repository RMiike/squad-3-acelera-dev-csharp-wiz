using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentralDeErro.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        #region Get
        //TODO Passar token via authorization
        //get: v1/testlog
        [HttpGet("testlog")]
        public IActionResult Get()
        {
            return Ok(new Error(1, "token", "titulo",  "detalhe", Level.Debug, DateTime.Now, 1));
        }


        //get: v1/alllogs

        [HttpGet("alllogs")]
        public ActionResult<IEnumerable<Error>> GetAll([FromServices] IErrorRepository _errorRepository)
        {
            return Ok(_errorRepository.Get());
        }
        ////get: v1/allarchivedlogs

        //[HttpGet("allarchivedlogs")]
        //public ActionResult<IEnumerable<Error>> GetAllArchived([FromServices] IErrorRepository _errorRepository)
        //{
        //    return Ok(_errorRepository.GetArchived());
        //}
        ////get: v1/allunarchivedlogs

        //[HttpGet("allunarchivedlogs")]
        //public ActionResult<IEnumerable<Error>> GetAllUnarchived([FromServices] IErrorRepository _errorRepository)
        //{
        //    return Ok(_errorRepository.GetUnarchived());
        //}
        //// GET: v1/log/5
        [HttpGet("log/{id}", Name = "GetById")]
        public ActionResult<Error> GetById([FromServices] IErrorRepository _errorRepository, int id)
        {
            var log = _errorRepository.Get(id);
            if (log != null)
            {
                return Ok(log);
            }
            return NotFound(new { message = "Error Id not found." });
        }

        //#endregion

        //#region Post

        //[HttpPost("addlog")]
        //public ActionResult<Error> Register(
        //    [FromServices] IErrorRepository _errorRepository,
        //        ErrorCreateDTO logErroDTO,
        //        [FromHeader] string Authorization
        //        )
        //{
        //    var result =   _errorRepository.Create(logErroDTO, Authorization);

        //    if (result.Success == true)
        //        return CreatedAtRoute(nameof(GetById), new { Id = logErroDTO.Title }, result);

        //    return BadRequest(result);
        //}
        //#endregion


        //#region  Put Patch

        ////patch: v1/archive
        ////patch: v1/unarchive
        ////patch: v1/delete
        ////TODO - set arquivado
        //// set desarquivado
        ////set delet?
        //[HttpPut("archive/{id}")]
        //public ActionResult Archive(
        //    [FromServices] IErrorRepository _errorRepository,
        //    [FromRoute]int id,
        //    [FromBody]ErrorCreateDTO logErroCreateDTO)
        //{
        //    var logErroById = _errorRepository.Update(id, logErroCreateDTO);

        //    if (logErroById == null)
        //    {
        //        return NotFound();
        //    }


        //    return NoContent();
        //}

        //// //patch?

        //#endregion

        //#region Delete

        //// // DELETE: api/ApiWithActions/5
        //// [HttpDelete("{id}")]
        //// public ActionResult Delete(int id)
        //// {
        ////     var logErroById = _logErroRepository.GetLogById(id);
        ////     if (logErroById == null)
        ////     {
        ////         return NotFound();
        ////     }

        ////     _logErroRepository.DeleteLog(logErroById);
        ////     _logErroRepository.SaveChanges();

        ////     return Ok("Deletado com sucesso.");
        //// }
        #endregion
    }
}
