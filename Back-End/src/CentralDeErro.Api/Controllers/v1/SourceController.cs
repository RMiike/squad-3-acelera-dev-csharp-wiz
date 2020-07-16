using System.Collections.Generic;
using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.WebAPI.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    public class SourceController : ControllerBase
    {

        #region get

        [HttpGet("allsources")]
        public ActionResult<IEnumerable<Source>> GetAll([FromServices] ISourceRepository _sourceRepository)
        {
            return Ok(_sourceRepository.Get());
        }


        [HttpGet("source/{id}", Name = "GetSourceById")]
        public ActionResult<Source> GetSourceById([FromServices] ISourceRepository _sourceRepository, int id)
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
        public ActionResult<Source> Register(
           [FromServices] ISourceRepository _sourceRepository,
                SourceCreateDTO sourceCreateDTO)
        {
            sourceCreateDTO.Validate();
            if (sourceCreateDTO.Invalid)
            {
                return BadRequest(new ResultDTO(false, "An error ocurred.", sourceCreateDTO.Notifications));
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
                return NotFound(result);

            return Ok(result);
        }
        #endregion
    }
}
