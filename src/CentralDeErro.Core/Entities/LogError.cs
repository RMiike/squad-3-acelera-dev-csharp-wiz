using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Core.Entities
{
    public enum Level {Error, Warning, Debug}
    public class LogError
    {
        public LogError()
        {
            Moment = DateTime.Now;
        }

        public int Id { get; set; }
        public string UserToken { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Moment { get; set; }
        public Level Level {get;set;}
        public int Event { get; set; }
//TODO sourceId ou Source
        public int SourceId { get; set; }
        public Source Source { get; set; }

    }
}
