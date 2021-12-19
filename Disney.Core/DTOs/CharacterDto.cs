using System.Collections.Generic;

namespace Disney.Core.DTOs
{
    public class CharacterDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public float Weight { get; set; }
        public string History { get; set; }
        public List<int> MovieIds { get; set; }
    }
}