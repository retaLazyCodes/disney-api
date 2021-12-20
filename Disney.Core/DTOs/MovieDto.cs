using System;
using System.ComponentModel.DataAnnotations;
using Disney.Core.Enumerations;

namespace Disney.Core.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "An Movie Title is required")]
        [StringLength(100)]
        public string Title { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "ReleaseDate is required")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1, 5,
            ErrorMessage = "Score must be between 1 and 5")]
        public Score Score { get; set; }

        [Required]
        [Range(1, int.MaxValue, 
            ErrorMessage = "GenreId must be a value bigger or equal than {1}")]
        public int GenreId { get; set; }
    }
}