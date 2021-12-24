using System.ComponentModel.DataAnnotations;

namespace Disney.Core.QueryFilters
{
    public class CharacterQueryFilter
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Movie { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "PageSize must be a value bigger or equal than {1}")]
        public int PageSize { get; set; } 
        
        [Range(0, int.MaxValue, ErrorMessage = "PageNumber must be a value bigger or equal than {1}")]
        public int PageNumber { get; set; }

    }
}