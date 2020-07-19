using System.Collections.Generic;
using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.WebAPI.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        #region Get
        [HttpGet("errors")]
        public ActionResult<IEnumerable<Error>> GetAll([FromServices] IErrorRepository _errorRepository)
        {
            return Ok(_errorRepository.Get());
        }

        [HttpGet("error/{id}", Name = "GetErrorById")]
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

        [HttpPost("error")]
        public ActionResult<Error> Register(
            [FromServices] IErrorRepository _errorRepository,
                ErrorCreateDTO logErroDTO,
                [FromHeader] string Authorization)
        {
            logErroDTO.Validate();
            if (logErroDTO.Invalid)
                return BadRequest(new ResultDTO(false, "An error ocurred.", logErroDTO.Notifications));

            var result = _errorRepository.Create(logErroDTO, Authorization);

            if (result.Success == true)
                return CreatedAtRoute(nameof(GetErrorById), new { Id = logErroDTO.Title }, result);

            return BadRequest(result);
        }
        #endregion

        #region Put

        [HttpPut]
        [Route("error/archive/{id}")]
        public ActionResult Archive(
            [FromServicesAttribute] IErrorRepository _errorrepository,
            [FromRoute] int id)
        {
            var logerrobyid = _errorrepository.Archive(id);

            if (logerrobyid.Success == false)
                return BadRequest(logerrobyid);


            return Ok(logerrobyid);
        }
        [HttpPut]
        [Route("error/unarchive/{id}")]
        public ActionResult Unarchive(
          [FromServicesAttribute] IErrorRepository _errorrepository,
          [FromRoute] int id)
        {
            var logerrobyid = _errorrepository.Unarchive(id);

            if (logerrobyid.Success == false)
                return BadRequest(logerrobyid);


            return Ok(logerrobyid);
        }

        [HttpDelete("error/{id}")]
        public ActionResult Delete(
          [FromServicesAttribute] IErrorRepository _errorrepository,
          [FromRoute] int id)
        {
            var logerrobyid = _errorrepository.Delete(id);

            if (logerrobyid.Success == false)
                return BadRequest(logerrobyid);


            return Ok(logerrobyid);
        }


        #endregion
    }
}
