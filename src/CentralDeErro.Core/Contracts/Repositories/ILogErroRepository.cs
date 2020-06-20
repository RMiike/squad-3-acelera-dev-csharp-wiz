using CentralDeErro.Core.Entities;
using System.Collections.Generic;

namespace CentralDeErro.Infrastructure.Interface
{
    public interface ILogErroRepository
    {
        bool SaveChanges();
        IEnumerable<Error> GetAllLogs();
        Error GetLogById(int id);

        void CreateLog(Error log);

        void UpdateLog(Error log);

        void DeleteLog(Error log);
    }
}
