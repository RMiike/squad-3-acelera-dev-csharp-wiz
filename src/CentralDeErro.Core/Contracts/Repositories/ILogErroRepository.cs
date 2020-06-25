using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using System.Collections.Generic;

namespace CentralDeErro.Infrastructure.Interface
{
    public interface ILogErroRepository
    {
        IEnumerable<Error> Get();
        Error Get(int id);
        ResultDTO Create(LogErroDTO logErroDTO);

        void Update(Error log);

        void Delete(Error log);
    }
}
