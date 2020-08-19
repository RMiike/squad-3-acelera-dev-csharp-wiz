using System.Threading.Tasks;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.WebAPI.Controllers.v1
{
               
    [Route("v1")]
    [ApiController]
    public class AccountManageController : ControllerBase
    {
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(
            [FromServices] IAccountManagerService _accountManagerService,
            [FromBody] ChangePasswordDTO changePasswordDTO)
        {
            changePasswordDTO.Validate();
            if (changePasswordDTO.Invalid)
                return BadRequest(new ResultDTO(false, "An error ocurred.", changePasswordDTO.Notifications));

            var result = await _accountManagerService.ChangePassword(changePasswordDTO, User);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

    }
}
