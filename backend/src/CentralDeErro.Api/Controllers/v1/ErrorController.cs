using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CentralDeErro.Api.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        #region Get
        //get: v1/testlog
        [HttpGet("testlog")]
        public IActionResult Get()
        {
            var mockError = Error.Create(1, "token", "titulo", "detalhe", Level.Debug, 1);
            return Ok(mockError);
        }


        //get: v1/alllogs

        [HttpGet("alllogs")]
        public ActionResult<IEnumerable<Error>> GetAll([FromServices] IErrorRepository _errorRepository)
        {
            return Ok(_errorRepository.Get());
        }

        // GET: v1/log/5
        [HttpGet("log/{id}", Name = "GetErrorById")]
        public ActionResult<Error> GetErrorById([FromServices] IErrorRepository _errorRepository, int id)
        {
            var log = _errorRepository.Get(id);
            if (log != null)
            {
                return Ok(log);
            }
            return NotFound(new { message = "Error Id not found." });
        }

        #endregion

        #region post

        [HttpPost("adderror")]
        public ActionResult<Error> Register(
            [FromServices] IErrorRepository _errorRepository,
                ErrorCreateDTO logErroDTO,
                [FromHeader] string Authorization)
        {
            logErroDTO.Validate();
            if (logErroDTO.Invalid)
                return Ok(new ResultDTO(false, "Fail.", logErroDTO.Notifications));

            var result = _errorRepository.Create(logErroDTO, Authorization);

            if (result.Success == true)
                return CreatedAtRoute(nameof(GetErrorById), new { Id = logErroDTO.Title }, result);

            return BadRequest(result);
        }
        #endregion

        #region Put

        [HttpPut("archive/{id}")]
        public ActionResult MarkAsArchived(
            [FromServicesAttribute] IErrorRepository _errorrepository,
            [FromRoute] int id)
        {
            var logerrobyid = _errorrepository.Archive(id);

            if (logerrobyid.Success == false)
                NotFound(logerrobyid);


            return Ok(logerrobyid);
        }
        [HttpPut("unarchive/{id}")]
        public ActionResult MarkAsUnrchive(
          [FromServicesAttribute] IErrorRepository _errorrepository,
          [FromRoute] int id)
        {
            var logerrobyid = _errorrepository.Unarchive(id);

            if (logerrobyid.Success == false)
                NotFound(logerrobyid);


            return Ok(logerrobyid);
        }

        [HttpPut("deleteerror/{id}")]
        public ActionResult MarkAsDelete(
          [FromServicesAttribute] IErrorRepository _errorrepository,
          [FromRoute] int id)
        {
            var logerrobyid = _errorrepository.Delete(id);

            if (logerrobyid.Success == false)
                NotFound(logerrobyid);


            return Ok(logerrobyid);
        }


        #endregion
    }
}
