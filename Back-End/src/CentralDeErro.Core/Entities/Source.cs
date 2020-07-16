using CentralDeErro.Core.Enums;
using System;
using System.Collections.Generic;

namespace CentralDeErro.Core.Entities
{
    public class Source
    {
        protected Source() { }
        private Source(int id, string address, Enums.Environment environment, bool deleted)
        {
            Id = id;
            Address = address;
            Environment = environment;
            Deleted = deleted;
        }

        public int Id { get; }
        public string Address { get; }
        public Enums.Environment Environment { get; }
        public bool Deleted { get;  set; }
        public IEnumerable<Error> Errors { get; }

        public static Source Create(int id, string address, Enums.Environment environment)
        {
            if (String.IsNullOrEmpty(address))
                throw new ArgumentNullException();

            var deleted = false;
            return new Source(id, address, environment, deleted);
        }
        public void Delete()
        {
            if (Deleted == true)
                throw new InvalidOperationException();

            Deleted = true;
        }
    }
}
