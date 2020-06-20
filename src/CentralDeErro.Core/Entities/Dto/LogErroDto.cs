using CentralDeErro.Core.Entities;
using System;

namespace CentralDeErro.Core.Entities.Dto
{
    public class LogErroDto
    {

        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Moment { get; set; }
        public int Event { get; set; }
        public int EnvironmentId { get; set; }
        public Entities.Environment Environment { get; set; }
        public int LevelId { get; set; }

        public Level Level { get; set; }
        public int SourceId { get; set; }

        public Source Source { get; set; }
    }
}
