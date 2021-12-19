using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Disney.Core.Enumerations;

namespace Disney.Core.DTOs
{
    public class MovieWithCharacters
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Score Score { get; set; }
        public int GenreId { get; set; }
        public List<CharacterWithoutMovies> Characters { get; set; }
    }
}