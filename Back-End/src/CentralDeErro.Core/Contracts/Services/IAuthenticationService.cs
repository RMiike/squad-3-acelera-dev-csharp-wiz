using CentralDeErro.Core.Entities.DTOs;
using System.Threading.Tasks;

namespace CentralDeErro.Core.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<ResultDTO> Register(RegisterCreateDTO registerDTO);
        Task<ResultDTO> Login(LoginCreateDTO loginDTO);
        Task<ResultDTO> ConfirmEmail(string userMail, string token);
        Task<ResultDTO> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
    }
}
