using System.ComponentModel.DataAnnotations;

namespace CinemaBasicExample.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(15, int.MaxValue)]
        public int Duration { get; set; } // Duration in minutes

        [Required]
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }

}
