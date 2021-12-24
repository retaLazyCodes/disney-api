namespace Disney.Core.QueryFilters
{
    public class CharacterQueryFilter
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Movie { get; set; }
        public int PageSize { get; set; } 
        public int PageNumber { get; set; }

    }
}