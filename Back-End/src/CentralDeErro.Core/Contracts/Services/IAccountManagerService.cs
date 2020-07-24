using CentralDeErro.Core.Entities.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CentralDeErro.Core.Contracts.Services
{
    public interface IAccountManagerService
    {
        Task<ResultDTO> ChangePassword(ChangePasswordDTO changePasswordDTO, ClaimsPrincipal user);
        Task<ResultDTO> GetByEmail(ClaimsPrincipal userClaims);
    }
}
