using CentralDeErro.Core.Entities.Dto;
using System.Threading.Tasks;

namespace CentralDeErro.Core.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationOutPut> Register(RegisterDTO registerDTO);
        Task<AuthenticationOutPut> Login(LoginDTO loginDTO);
    }
}
