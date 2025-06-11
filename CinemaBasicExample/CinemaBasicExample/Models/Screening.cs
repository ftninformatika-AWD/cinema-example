using System.ComponentModel.DataAnnotations;

namespace CinemaBasicExample.Models
{
    public class Screening
    {
        public int Id { get; set; }

        [Required]
        public DateTime ScheduledAt { get; set; }

        [Required]
        [Range(1, 20)]
        public int Room { get; set; }

        [Required]
        [MinLength(2)]
        public string ScreeningType { get; set; } = string.Empty;

        [Required]
        [Range(5, 400)]
        public double TicketPrice { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
