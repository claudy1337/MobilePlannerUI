using System.ComponentModel.DataAnnotations;

namespace MobilePlanner.Domain
{
    public class Planner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
