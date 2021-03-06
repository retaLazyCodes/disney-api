using System;
using System.Collections.Generic;
using Disney.Core.Enumerations;

namespace Disney.Core.Entities
{
    public class Movie: BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Score Score { get; set; }
        public int GenreId { get; set; }
        public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
    }
}