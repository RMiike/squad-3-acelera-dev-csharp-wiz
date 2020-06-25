using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
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
        private readonly IMapper _mapper;

        public LogErroRepository(
            CentralDeErrorContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
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
        

        public ResultDTO Create(LogErroDTO logErroDTO)
        {
            if (logErroDTO == null)
                throw new ArgumentNullException();

            var logErro = _mapper.Map<Error>(logErroDTO);
            logErro.AddToken("aspdksaopdk");
           
            _context.Add(logErro);
            if (SaveChanges() == true)
                return new ResultDTO(true, "Succesfully registred the error.", logErro);

            return new ResultDTO(false, "Fail", null);

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
        private bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    }
}
