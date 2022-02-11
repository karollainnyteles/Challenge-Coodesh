namespace Coodesh.Challenge.Business.Parameters
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;

        public int GetSkip()
        {
            PageNumber = PageNumber < 1 ? 1 : PageNumber;
            return (PageNumber - 1) * PageSize;
        }
    }
}