﻿using AutoMapper;
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
    public class ErroRepository
        : IErrorRepository
    {
        private readonly CentralDeErrorContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ErroRepository(
            CentralDeErrorContext context,
            IMapper mapper,
            UserManager<User> userManager

            )
        {
            _context = context;
            _userManager = userManager;
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


        ////TODO - verificar a forma mais viavel de remover...
        ////sera adicionada a outra trabela ou apenas setada como excluida?
        ////verificar arquivamento também.

        //public ResultDTO Update(int id, ErrorCreateDTO logErroCreateDTO)
        //{
        //    var error = _context.Errors.Select(error => error).Where(error => error.Id == id);

        //    if (error == null) 
        //        return new ResultDTO(false, $"Error id: {id} not found.", null);

        //    //error.

        //    return new ResultDTO(true, "true", null);
        //}
        //public void Delete(ErrorCreateDTO logErroDTO)
        //{
        //    if (logErroDTO == null)
        //        throw new ArgumentNullException();

        //    _context.Remove(logErroDTO);
        //}
        private bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    

        public void Delete(ErrorCreateDTO logErroDTO)
        {
            throw new NotImplementedException();
        }

                              public ResultDTO Update(int id, ErrorCreateDTO logErroCreateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
