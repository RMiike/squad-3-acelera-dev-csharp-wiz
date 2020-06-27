using System.Threading.Tasks;
using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.Api.Controllers.v1
{
    [Route("v1")]
    [ApiController]
    public class AccountManageController : ControllerBase
    {
        //Alterar dados da conta/ senha

        // GET: v1/changepassword
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(
            [FromServices]  IAccountManagerService _accountManagerService,
            [FromBody] ChangePasswordDTO changePasswordDTO
            )
        {
            var result = await _accountManagerService.ChangePassword(changePasswordDTO, User);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
