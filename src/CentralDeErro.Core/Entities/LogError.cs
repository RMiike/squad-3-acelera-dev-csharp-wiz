using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Core.Entities
{
    public class LogError
    {
        public LogError()
        {
            Moment = DateTime.Now;
        }

        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        //TODO entity source?
        public string Source { get; set; }
        public DateTime Moment { get; set; }
        //TODO enum level?
        public string Level { get; set; }
        public int Event { get; set; }

        //TODO entity enviroment?
        public string Environment { get; set; }
    }
}
