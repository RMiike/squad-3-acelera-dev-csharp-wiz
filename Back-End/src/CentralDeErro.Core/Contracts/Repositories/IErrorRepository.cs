using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;
using System.Security.Claims;

namespace CentralDeErro.Core.Contracts.Repositories
{
    public interface IErrorRepository
    {
        IEnumerable<ErrorReadDTO> Get();
        ErrorReadDTO Get(int id);
        ResultDTO Create(ErrorCreateDTO logErroDTO, ClaimsPrincipal user);
        ResultDTO Archive(int id);
        ResultDTO Unarchive(int id);
        ResultDTO Delete(int id);
    }
}
