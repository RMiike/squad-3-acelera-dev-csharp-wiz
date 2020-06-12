using CentralDeErro.Core.Entities;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Application
{
    public class LogErroService : ILogErroService
    {
        public IEnumerable<LogErro> GetAllLogs()
        {
            var log = new List<LogErro> {
             new LogErro(1,"aposkdpoaskd","LogDeErroX", "falha no log x", 2,1,2,3),
            new LogErro(1,"aposkdpoaskd","LogDeErroX", "falha no log x", 2,1,2,3),
             new LogErro(1,"aposkdpoaskd","LogDeErroX", "falha no log x", 2,1,2,3),
            new LogErro(1,"aposkdpoaskd","LogDeErroX", "falha no log x", 2,1,2,3)
      };
            return log;
        }
        public void CreateLog(LogErro log)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(LogErro log)
        {
            throw new NotImplementedException();
        }


        public LogErro GetLogById(int id)
        {

            return new LogErro(1, "aposkdpoaskd", "LogDeErroX", "falha no log x", 2, 1, 2, 3);
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateLog(LogErro log)
        {
            throw new NotImplementedException();
        }
    }
}
