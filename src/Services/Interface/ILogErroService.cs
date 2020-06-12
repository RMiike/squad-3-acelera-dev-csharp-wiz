using CentralDeErro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface ILogErroService
    {
        bool SaveChanges();
        IEnumerable<LogErro> GetAllLogs();
        LogErro GetLogById(int id);

        void CreateLog(LogErro log);

        void UpdateLog(LogErro log);

        void DeleteLog(LogErro log);
    }
}
