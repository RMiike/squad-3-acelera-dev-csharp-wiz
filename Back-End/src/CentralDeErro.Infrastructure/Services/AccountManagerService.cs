using CentralDeErro.Core.Contracts.Services;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CentralDeErro.Infrastructure.Services
{
    public class AccountManagerService : IAccountManagerService
    {
        #region controler and private
        private readonly UserManager<User> _userManager;
        public AccountManagerService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        public async Task<ResultDTO> ChangePassword(ChangePasswordDTO changePasswordDTO, ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            if (user == null)
                return new ResultDTO(false, $"User {_userManager.GetUserId(userClaims)} data not found!", null);

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);

            if (!result.Succeeded)
            {
                var listError = new List<IdentityError>();
                foreach (var error in result.Errors)
                {
                    listError.Add(error);
                }
                return new ResultDTO(false, "An error ocurred.", listError);
            }
            return new ResultDTO(true, "Password was changed successfully.", null);
        }
        public async Task<ResultDTO> GetByEmail(ClaimsPrincipal userClaims)
        {
            var user = await _userManager.GetUserAsync(userClaims);
            if (user == null)
                return new ResultDTO(false, $"User {_userManager.GetUserId(userClaims)} data not found!", null);

            return new ResultDTO(true, $"Data actual user.", new { user.Id, user.FullName, user.CreatedAt });
        }
    }
}
