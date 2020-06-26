using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CentralDeErro.Core.Entities
{
    [Table("Level")]
    public class Level
    {
        public Level(int id, string description)
        {
            Id = id;
            Description = description;
        }

        [Key]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(60, ErrorMessage = "This field must be between 6 and 20 characters", MinimumLength = 6)]
        public string Description { get; private set; }
        //public IEnumerable<Error> Errors { get; set; }
    }
}
