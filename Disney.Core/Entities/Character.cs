using System.Collections.Generic;

namespace Disney.Core.Entities
{
    public class Character: BaseEntity 
    {
        public Character()
        {
            Movies = new HashSet<Movie>();
        }
        
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}