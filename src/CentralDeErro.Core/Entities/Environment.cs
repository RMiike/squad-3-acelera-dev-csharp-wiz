using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Core.Entities
{
    public class Environment
    {
        public Environment()
        {

        }

        public Environment(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public IList<LogError> LogsError { get; set; }

    }
}
