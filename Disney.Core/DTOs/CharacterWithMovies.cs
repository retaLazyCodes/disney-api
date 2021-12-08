using System.Collections.Generic;

namespace Disney.Core.DTOs
{
    public class CharacterWithMovies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public List<MovieDto> Movies { get; set; }
    }
}