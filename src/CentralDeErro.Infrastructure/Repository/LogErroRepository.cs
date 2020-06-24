using CentralDeErro.Core.Entities;
using CentralDeErro.Infrastructure.Context;
using CentralDeErro.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Error> Get()
            => _context
                .Errors
                .AsNoTracking()
                .Include(l => l.Environment)
                .Include(s => s.Source)
                .Include(e => e.Environment)
                .OrderBy(err => err.CreatedAt);
    
        public Error Get(int id)
            => _context
                .Errors
                .AsNoTracking()
                .Include(l => l.Environment)
                .Include(s => s.Source)
                .Include(e => e.Environment)
                .OrderBy(err => err.CreatedAt)
                .FirstOrDefault(p => p.Id == id);
        

        public async void Create(Error log)
        {
            if (log == null)
                throw new ArgumentNullException();

           await _context.AddAsync(log);
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

        public void Update(Error log)
        {
            //throw new NotImplementedException();
        }
        public bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    }
}
