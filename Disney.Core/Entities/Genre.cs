using System.Collections.Generic;

namespace Disney.Core.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}