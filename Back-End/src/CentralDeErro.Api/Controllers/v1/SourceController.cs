using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CentralDeErro.Api.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        #region get
        [HttpGet("testsource")]
        public IActionResult Get()
        {
            var mockError = Source.Create(1, "192.002.123", Environment.Development);
            return Ok(mockError);
        }


        [HttpGet("allsources")]
        public ActionResult<IEnumerable<Error>> GetAll([FromServices] ISourceRepository _sourceRepository)
        {
            return Ok(_sourceRepository.Get());
        }


        [HttpGet("source/{id}", Name = "GetSourceById")]
        public ActionResult<Error> GetSourceById([FromServices] ISourceRepository _sourceRepository, int id)
        {
            var source = _sourceRepository.Get(id);
            if (source != null)
            {
                return Ok(source);
            }
            return NotFound(new { message = "Source Id not found." });
        }
        #endregion

        #region post

        [HttpPost("addsource")]
        public ActionResult<Error> Register(
           [FromServices] ISourceRepository _sourceRepository,
                SourceCreateDTO sourceCreateDTO)
        {
            sourceCreateDTO.Validate();
            if (sourceCreateDTO.Invalid)
            {
                return Ok(new ResultDTO(false, "An error ocurred.", sourceCreateDTO.Notifications));
            }

            var result = _sourceRepository.Create(sourceCreateDTO);

            if (result.Success == true)
                return CreatedAtRoute(nameof(GetSourceById), new { Id = sourceCreateDTO.Id }, result);

            return BadRequest(result);
        }
        #endregion

        #region delete
        [HttpDelete("deletesource/{id}")]
        public ActionResult Delete(
          [FromServicesAttribute] ISourceRepository _sourceRepository,
          [FromRoute] int id)
        {
            //TODO
            var result = _sourceRepository.Delete(id);

            if (result.Success == false)
                NotFound(result);

            return Ok(result);
        }
        #endregion
    }
}
