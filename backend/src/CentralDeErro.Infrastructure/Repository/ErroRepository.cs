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
    public class ErroRepository
        : IErrorRepository
    {
        private readonly CentralDeErrorContext _context;
        private readonly IMapper _mapper;

        public ErroRepository(
            CentralDeErrorContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ErrorReadDTO> Get()
          => _context
                .Errors
                .Where( e=> e.Deleted == false)
                .Select(e => new ErrorReadDTO(
                e.Id,
                e.Token,
                e.Title,
                e.Details,
                e.CreatedAt,
                e.Level.ToString(),
                e.Source.Environment.ToString(),
                e.Source.Address,
                e.Archived
                ))
                .AsNoTracking()
                .ToList();

        public IEnumerable<ErrorReadDTO> GetArchived()
               => _context
                .Errors
                .Where(e => e.Deleted == false && e.Archived == true)
                .Select(e => new ErrorReadDTO(
                e.Id,
                e.Token,
                e.Title,
                e.Details,
                e.CreatedAt,
                e.Level.ToString(),
                e.Source.Environment.ToString(),
                e.Source.Address,
                e.Archived
                ))
                .AsNoTracking()
                .ToList();

        public IEnumerable<ErrorReadDTO> GetUnarchived()
          => _context
                .Errors
                .Where(e => e.Deleted == false && e.Archived == false)
                .Select(e => new ErrorReadDTO(
                e.Id,
                e.Token,
                e.Title,
                e.Details,
                e.CreatedAt,
                e.Level.ToString(),
                e.Source.Environment.ToString(),
                e.Source.Address,
                e.Archived
                ))
                .AsNoTracking()
                .ToList();

        public ErrorReadDTO Get(int id)
            => _context
                .Errors
                .Where(e => e.Deleted == false && e.Id == id)
                .Select(e => new ErrorReadDTO(
                e.Id,
                e.Token,
                e.Title,
                e.Details,
                e.CreatedAt,
                e.Level.ToString(),
                e.Source.Environment.ToString(),
                e.Source.Address,
                e.Archived
                ))
                .AsNoTracking()
                .FirstOrDefault();


        public ResultDTO Create(ErrorCreateDTO logErroDTO, string token)
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



        public ResultDTO Archive(int id)
        {
            var error = _context.Errors.Select(error => error).Where(error => error.Id == id && error.Deleted == false).FirstOrDefault();

            if (error == null)
                return new ResultDTO(false, $"Error id: {id} not found.", null);

            if (error.Archived == true)
                return new ResultDTO(false, $"Error id: {id} already archived.", null);

            error.MarkAsArchived();
            SaveChanges();
            return new ResultDTO(true, "Successfuly archived", error);
        }

        public ResultDTO Unarchive(int id)
        {
            var error = _context.Errors.Select(error => error).Where(error => error.Id == id && error.Deleted == false).FirstOrDefault();

            if (error == null)
                return new ResultDTO(false, $"Error id: {id} not found.", null);

            if (error.Archived == false)
                return new ResultDTO(false, $"Error id: {id} already unarchived.", null);

            error.MarkAsUnarchived();
            SaveChanges();
            return new ResultDTO(true, "Successfuly unarchived", error);
        }

        public ResultDTO Delete(int id)
        {
            var error = _context.Errors.Select(error => error).Where(error => error.Id == id && error.Deleted == false).FirstOrDefault();

            if (error == null)
                return new ResultDTO(false, $"Error id: {id} not found.", null);

           
            error.MarkAsDeleted();
            SaveChanges();
            return new ResultDTO(true, "Successfuly deleted", error);
        }

        private bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    }
}
