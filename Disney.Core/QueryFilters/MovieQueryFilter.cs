namespace Disney.Core.QueryFilters
{
    public class MovieQueryFilter
    {
        public string Title { get; set; }
        public int? Genre { get; set; }
        public string Order { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}