using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;

namespace CentralDeErro.Core.Contracts.Repositories
{
    public interface IErrorRepository
    {
        IEnumerable<ErrorReadDTO> Get();
        ErrorReadDTO Get(int id);
        ResultDTO Create(ErrorCreateDTO logErroDTO, string user);
        ResultDTO Archive(int id);
        ResultDTO Unarchive(int id);
        ResultDTO Delete(int id);
    }
}
