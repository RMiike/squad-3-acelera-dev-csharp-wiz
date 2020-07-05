using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;

namespace CentralDeErro.Core.Contracts.Repositories
{
    public interface ISourceRepository
    {
        IEnumerable<SourceReadDTO> Get();
        SourceReadDTO Get(int id);
        ResultDTO Create(SourceCreateDTO sourceCreateDTO);
        ResultDTO Delete(int id);
    }
}
