using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;

namespace CentralDeErro.Infrastructure.Interface
{
    public interface IErrorRepository
    {
        IEnumerable<ErrorReadDTO> Get();
        IEnumerable<ErrorReadDTO> GetArchived();
        IEnumerable<ErrorReadDTO> GetUnarchived();
        ErrorReadDTO Get(int id);
        ResultDTO Create(ErrorCreateDTO logErroDTO, string user);
        ResultDTO Archive(int id);
        ResultDTO Unarchive(int id);
        ResultDTO Delete(int id);
    }
}
