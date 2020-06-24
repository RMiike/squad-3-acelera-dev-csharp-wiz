using CentralDeErro.Core.Entities;
using System.Collections.Generic;

namespace CentralDeErro.Infrastructure.Interface
{
    public interface ILogErroRepository
    {

        bool SaveChanges();
        IEnumerable<Error> Get();
        Error Get(int id);
        void Create(Error log);

        void Update(Error log);

        void Delete(Error log);
    }
}
