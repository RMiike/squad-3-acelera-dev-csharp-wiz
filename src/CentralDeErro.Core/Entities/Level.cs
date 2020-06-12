using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Core.Entities
{
    public class Level 
    {
        public Level()
        {

        }

        public Level(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public IList<LogErro> LogsError { get; set; }

    }
}
