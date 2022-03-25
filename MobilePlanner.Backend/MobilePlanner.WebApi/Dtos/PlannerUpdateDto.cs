using System.ComponentModel.DataAnnotations;

namespace MobilePlanner.WebApi.Dtos
{
    public class PlannerUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
