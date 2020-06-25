using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;
using System.Security.Claims;

namespace CentralDeErro.Infrastructure.Interface
{
    public interface ILogErroRepository
    {
        IEnumerable<LogErroReadDTO> Get();
        IEnumerable<LogErroReadDTO> GetArchived();
        IEnumerable<LogErroReadDTO> GetUnarchived();
        LogErroReadDTO Get(int id);
        ResultDTO Create(LogErroCreateDTO logErroDTO, string user);

        ResultDTO Update(int id, LogErroCreateDTO logErroCreateDTO);

        void Delete(LogErroCreateDTO logErroDTO);
    }
}
