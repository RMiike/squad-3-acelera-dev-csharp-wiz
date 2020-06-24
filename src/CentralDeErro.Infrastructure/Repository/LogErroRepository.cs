using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Context;
using CentralDeErro.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErro.Infrastructure.Repository
{
    public class LogErroRepository 
        : ILogErroRepository
    {
        private readonly CentralDeErrorContext _context;

        public LogErroRepository(CentralDeErrorContext context)
        {
            _context = context;
        }
        public void Create(Error log)
        {
            if (log == null)
                throw new ArgumentNullException();

            _context.Add(log);
        }


        //TODO - verificar a forma mais viavel de remover...
        //sera adicionada a outra trabela ou apenas setada como excluida?
        //verificar arquivamento também.
        public void Delete(Error log)
        {
            if (log == null)
                throw new ArgumentNullException();

            _context.Remove(log);
        }
        public Error Get(int id)
        {
            return _context.Errors.FirstOrDefault(p => p.Id == id);
        }
        public void Update(Error log)
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<Error> Get()
            => _context.Errors;

        public bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    }
}
