using CentralDeErro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Infrastructure.Interface
{
    public interface ILogErroRepository
    {
        bool SaveChanges();
        IEnumerable<LogErro> GetAllLogs();
        LogErro GetLogById(int id);

        void CreateLog(LogErro log);

        void UpdateLog(LogErro log);

        void DeleteLog(LogErro log);
    }
}
