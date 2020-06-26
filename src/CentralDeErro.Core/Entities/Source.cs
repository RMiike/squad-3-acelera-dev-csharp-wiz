using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErro.Core.Entities
{
    public enum Environment {Production, Homologation, Development}
    public class Source
    {
        public Source()
        {

        }

        public Source(int id, string address)
        {
            Id = id;
            Address = address;
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public Environment Environment{get;set;}
        public IList<LogError> LogsError { get; set; }
    }
}
