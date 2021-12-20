using System.ComponentModel.DataAnnotations;

namespace Disney.Core.DTOs
{
    public class GenreDto
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "An Genre Name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Image { get; set; } 
    }
}