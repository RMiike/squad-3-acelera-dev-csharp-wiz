using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErro.Core.Entities
{
    public enum _Environment {Production, Homologation, Development}

    [Table("Source")]
    public class Source
    {
        
        public Source(int id, string address, _Environment environment)
        {
            Id = id;
            Address = address;
            Environment = environment;
        }

        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        //TODO
        public string Address { get; private set; }

        public _Environment Environment {get; private set;}

        //public Level Level { get; set; }
        //public IEnumerable<Error> Errors { get; set; }

    }
}
