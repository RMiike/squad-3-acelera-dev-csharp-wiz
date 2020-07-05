using AutoMapper;
using CentralDeErro.Core.Contracts.Repositories;
using CentralDeErro.Core.Entities;
using CentralDeErro.Core.Entities.DTOs;
using CentralDeErro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CentralDeErro.Infrastructure.Repository
{
    public class SourceRepository : ISourceRepository
    {
        private readonly IMapper _mapper;
        private readonly CentralDeErrorContext _context;

        public SourceRepository(
             CentralDeErrorContext context,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _context = context;
        }
        public IEnumerable<SourceReadDTO> Get()
            => _context
                 .Sources
                .Where(s => s.Deleted == false)
                .Select(s => new SourceReadDTO(s.Id, s.Address, s.Environment.ToString()))
                .AsNoTracking()
                .ToList();

        public SourceReadDTO Get(int id)
            => _context
            .Sources
            .Where(s => s.Deleted == false && s.Id == id)
            .Select(s => new SourceReadDTO(s.Id, s.Address, s.Environment.ToString()))
            .AsNoTracking()
            .FirstOrDefault();



        public ResultDTO Create(SourceCreateDTO sourceCreateDTO)
        {
            if (sourceCreateDTO == null)
                throw new ArgumentNullException();


            var sourceData = _mapper.Map<Source>(sourceCreateDTO);

            _context.Add(sourceData);

            if (SaveChanges() == true)
                return new ResultDTO(true, "Succesfully registred the source.", sourceData);

            return new ResultDTO(false, "Fail", null);
        }

        public ResultDTO Delete(int id)
        {
            var source = _context
                .Sources
                .Select(sources => sources)
                .Where(sources => sources.Id == id && sources.Deleted == false)
                .FirstOrDefault();

            if (source == null)
                return new ResultDTO(false, $"Source id: {id} not found.", null);

            source.Delete();
            SaveChanges();

            return new ResultDTO(true, "Successfuly deleted", source);
        }
        private bool SaveChanges()
           => (_context.SaveChanges() >= 0);
    }
}
