﻿using AutoMapper;
using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace CentralDeErro.Infrastructure.Repository
{
    public class ErrorRepository
        : IErrorRepository
    {
        private readonly CentralDeErrorContext _context;
        private readonly IMapper _mapper;

        public ErrorRepository(
            CentralDeErrorContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

     

        public IEnumerable<ErrorReadDTO> Get()
          => HandleSearch(e => e.Deleted == false)
                .ToList();

        public ErrorReadDTO Get(int id)
            => HandleSearch(e => e.Deleted == false && e.Id == id)
                .FirstOrDefault();

        public ResultDTO Create(ErrorCreateDTO logErroDTO, ClaimsPrincipal user)
        {
            if (logErroDTO == null)
                throw new ArgumentNullException();

            if (!_context.Sources.Where(x => x.Deleted == false).Any(x => x.Id == logErroDTO.SourceId))
                return new ResultDTO(false, "Invalid Source Id.", null);

            var userId = user.Claims.FirstOrDefault().Value;    

            logErroDTO.AddUserId(userId);

            var logErro = _mapper.Map<Error>(logErroDTO);

            _context.Add(logErro);

            if (SaveChanges() == true)
                return new ResultDTO(true, "Succesfully registred the error.", logErro);

            return new ResultDTO(false, "Fail", null);
        }

        public ResultDTO Archive(int id)
        {
            var error = FindById(id);

            if (error == null)
                return new ResultDTO(false, $"Error id: {id} not found.", null);

            if (error.Archived == true)
                return new ResultDTO(false, $"Error id: {id} already archived.", null);

            error.Archive();
            SaveChanges();
            return new ResultDTO(true, "Successfuly archived", error);
        }

        public ResultDTO Unarchive(int id)
        {
            var error = FindById(id);

            if (error == null)
                return new ResultDTO(false, $"Error id: {id} not found.", null);

            if (error.Archived == false)
                return new ResultDTO(false, $"Error id: {id} already unarchived.", null);

            error.Unarchive();
            SaveChanges();
            return new ResultDTO(true, "Successfuly unarchived", error);
        }


        public ResultDTO Delete(int id)
        {
            var error = FindById(id);

            if (error == null)
                return new ResultDTO(false, $"Error id: {id} not found.", null);

            error.Delete();
            SaveChanges();
            return new ResultDTO(true, "Successfuly deleted", error);
        }

        private Error FindById(int id)
            => _context
                .Errors
                .Select(error => error)
                .Where(error => error.Id == id && error.Deleted == false)
                .FirstOrDefault();

        private IQueryable<ErrorReadDTO> HandleSearch(Expression<Func<Error, bool>> condition)
        {
            return _context
                            .Errors
                            .Where(condition)
                            .Select(e => new ErrorReadDTO(
                            e.Id,
                            e.UserId,
                            e.User.FullName,
                            e.Title,
                            e.Details,
                            e.CreatedAt,
                            e.Level.ToString(),
                            e.Source.Environment.ToString(),
                            e.Source.Address,
                            e.Archived
                            ))
                            .AsNoTracking();
        }
        private bool SaveChanges()
            => (_context.SaveChanges() >= 0);
    }
}
