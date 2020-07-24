using CentralDeErro.Core.Entities;
using System.Threading.Tasks;

namespace CentralDeErro.Core.Contracts.Services
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(User user);
        string GetClaimsOnToken(string token);
    }
}
