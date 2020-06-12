using CentralDeErro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface ILogErro
    {
        bool SaveChanges();
        IEnumerable<LogError> GetAllCommands();
        LogError GetCommandById(int id);

        void CreateCommand(LogError cmd);

        void UpdateCommand(LogError cmd);

        void DeleteCommand(LogError cmd);
    }
}
