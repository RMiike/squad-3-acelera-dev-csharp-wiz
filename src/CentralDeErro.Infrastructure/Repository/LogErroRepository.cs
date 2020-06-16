using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Context;
using CentralDeErro.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErro.Infrastructure.Repository
{
    public class LogErroRepository : ILogErroRepository
    {
        private readonly CentralDeErrorContext _context;

        public LogErroRepository(CentralDeErrorContext context)
         {
            _context = context;
        }


        public void CreateLog(LogErro log)
        {

            if(log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }
            _context.Add(log);
        }

        public void DeleteLog(LogErro log)
        {
            if (log == null)
            {
                throw new ArgumentNullException(nameof(log));
            }
            _context.Remove(log);
        }

        public IEnumerable<LogErro> GetAllLogs()
        {
            return _context.LogError.ToList();
        }

        public LogErro GetLogById(int id)
        {
            return _context.LogError.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLog(LogErro log)
        {
            //
        }
    }
}
