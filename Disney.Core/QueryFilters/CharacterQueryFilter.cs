using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Core.QueryFilters
{
    public class CharacterQueryFilter
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Movie { get; set; }
    }
}