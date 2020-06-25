using AutoMapper;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Context;
using CentralDeErro.Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CentralDeErro.Infrastructure.Repository
{
    public class LogErroRepository
        : ILogErroRepository
    {
        private readonly CentralDeErrorContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public LogErroRepository(
            CentralDeErrorContext context,
            IMapper mapper,
            UserManager<User> userManager

            )
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<LogErroReadDTO> Get()
            => (from error in _context.Errors
                join env in _context.Environments
                on error.EnvironmentId equals env.Id
                join lvl in _context.Environments
                on error.LevelId equals lvl.Id
                join src in _context.Environments
                on error.SourceId equals src.Id
                where error.Deleted.Equals(false)
                orderby error.CreatedAt descending
                select new LogErroReadDTO
               (error.Id,
                error.Token,
                error.Title,
                error.Details,
                error.CreatedAt,
                error.Event,
                env.Description,
                lvl.Description,
                src.Description,
                error.Archived
                ))
                    .AsNoTracking()
                    .ToList();

        public IEnumerable<LogErroReadDTO> GetArchived()
              => (from error in _context.Errors
                  join env in _context.Environments
                  on error.EnvironmentId equals env.Id
                  join lvl in _context.Environments
                  on error.LevelId equals lvl.Id
                  join src in _context.Environments
                  on error.SourceId equals src.Id
                  where error.Deleted == false && error.Archived == true
                  orderby error.CreatedAt descending
                  select new LogErroReadDTO
                 (error.Id,
                  error.Token,
                  error.Title,
                  error.Details,
                  error.CreatedAt,
                  error.Event,
                  env.Description,
                  lvl.Description,
                  src.Description,
                  error.Archived
                  ))
                    .AsNoTracking()
                    .ToList();

        public IEnumerable<LogErroReadDTO> GetUnarchived()
          => (from error in _context.Errors
              join env in _context.Environments
              on error.EnvironmentId equals env.Id
              join lvl in _context.Environments
              on error.LevelId equals lvl.Id
              join src in _context.Environments
              on error.SourceId equals src.Id
              where error.Deleted == false && error.Archived == false
              orderby error.CreatedAt descending
              select new LogErroReadDTO
             (error.Id,
              error.Token,
              error.Title,
              error.Details,
              error.CreatedAt,
              error.Event,
              env.Description,
              lvl.Description,
              src.Description,
              error.Archived
              ))
                    .AsNoTracking()
                    .ToList();

        public LogErroReadDTO Get(int id)
            => (from error in _context.Errors
                join env in _context.Environments
                on error.EnvironmentId equals env.Id
                join lvl in _context.Environments
                on error.LevelId equals lvl.Id
                join src in _context.Environments
                on error.SourceId equals src.Id
                where error.Deleted.Equals(false)
                where error.Id.Equals(id)
                orderby error.CreatedAt descending
                select new LogErroReadDTO
               (error.Id,
                error.Token,
                error.Title,
                error.Details,
                error.CreatedAt,
                error.Event,
                env.Description,
                lvl.Description,
                src.Description,
                error.Archived
                ))
                .AsNoTracking()
                .FirstOrDefault();


        public ResultDTO Create(LogErroCreateDTO logErroDTO, string token)
        {
            if (logErroDTO == null)
                throw new ArgumentNullException();

            var logErro = _mapper.Map<Error>(logErroDTO);
            logErro.AddToken(token);

            _context.Add(logErro);

            if (SaveChanges() == true)
                return new ResultDTO(true, "Succesfully registred the error.", logErro);

            return new ResultDTO(false, "Fail", null);

        }


        //TODO - verificar a forma mais viavel de remover...
        //sera adicionada a outra trabela ou apenas setada como excluida?
        //verificar arquivamento também.

        public ResultDTO Update(int id, LogErroCreateDTO logErroCreateDTO)
        {
            var error = _context.Errors.Select(error => error).Where(error => error.Id == id);

            if (error == null) 
                return new ResultDTO(false, $"Error id: {id} not found.", null);

            //error.

            return new ResultDTO(true, "true", null);
        }
        public void Delete(LogErroCreateDTO logErroDTO)
        {
            if (logErroDTO == null)
                throw new ArgumentNullException();

            _context.Remove(logErroDTO);
        }
        private bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    }
}
