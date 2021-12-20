using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.DTOs
{
    public class CharacterDto 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "An Character Name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; } = 0;
        public float Weight { get; set; } = 0;
        public string History { get; set; }
        public List<int> MovieIds { get; set; } = new List<int>();
    }
}