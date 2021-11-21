using System;
using System.Collections.Generic;
using Disney.Core.Enumerations;

namespace Disney.Core.Entities
{
    public class Movie
    {
        public Movie()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Score Score { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}