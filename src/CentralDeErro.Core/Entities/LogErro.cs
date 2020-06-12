using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Core.Entities
{
    public class LogErro
    {
        public LogErro()
        {
            Moment = DateTime.Now;
        }

        public LogErro(int id, string userToken, string title, string details, int @event, int environmentId, int levelId, int sourceId)
        {
            Id = id;
            UserToken = userToken;
            Title = title;
            Details = details;
            Moment = DateTime.Now;
            Event = @event;
            EnvironmentId = environmentId;
            LevelId = levelId;
            SourceId = sourceId;
        }

        public int Id { get; set; }
        public string UserToken { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Moment { get; set; }
        public int Event { get; set; }
        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }
        public int LevelId { get; set; }

        public Level Level { get; set; }
        public int SourceId { get; set; }

        public Source Source { get; set; }
        //arquivado / deletado?
    }
}
