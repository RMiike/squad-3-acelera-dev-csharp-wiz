using CentralDeErro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CentralDeErro.Infrastructure.Data.Maps
{
    public class ErrorMap : IEntityTypeConfiguration<Error>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Error> builder)
        {
            builder.HasData(
                    new Error(
                        1,
                       "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJkYzgyMTI2NDhhIiwidW5pcXVlX25hbWUiOiJtaWlrZTIyMjMiLCJuYmYiOjE1OTE5MDE1OTMsImV4cCI6MTU5MTk4Nzk5MywiaWF0IjoxNTkxOTAxNTkzfQ.Tn-dAuEsod3HM1nQuqoFQ8HppCvls3cKW8ps_8sIbMp2OxGjwivzqsen_nvA4hu49Wt_fjWGBXkCS5IHulJJAQ",
                       "Description Project File Suppression State Line",
                       @"Error CS7036  There is no argument given that corresponds to the required formal parameter 'id' of 'Error.Error(int, string, string, string, DateTime, int, int, int, int)'	EziLog.Infrastructure D:\source\repos\EziLog\src\EziLog.Infrastructure\Data\Maps\ErrorMap.cs Active  15",
                        DateTime.Now,
                        10010,
                        1,
                        1,
                        1));
        }
    }
}
