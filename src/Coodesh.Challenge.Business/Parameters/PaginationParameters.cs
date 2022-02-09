namespace Coodesh.Challenge.Business.Parameters
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
        public int Skip => PageSize * PageNumber;
    }
}