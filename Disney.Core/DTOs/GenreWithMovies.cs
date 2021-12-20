using System.Collections.Generic;

namespace Disney.Core.DTOs
{
    public class GenreWithMovies
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Image { get; set; }
        public List<MovieDto> Movies { get; set; }
    }
}