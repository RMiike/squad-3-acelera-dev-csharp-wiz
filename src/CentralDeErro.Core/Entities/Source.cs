using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErro.Core.Entities
{
    [Table("Source")]

    public class Source
    {
        public Source(int id, string description)
        {
            Id = id;
            Description = description;
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        public string Description { get; set; }

        //public Level Level { get; set; }
        //public IEnumerable<Error> Errors { get; set; }

    }
}
