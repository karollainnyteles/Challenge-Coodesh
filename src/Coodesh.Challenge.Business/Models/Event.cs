namespace Coodesh.Challenge.Business.Models
{
    public class Event : Entity
    {
        public int ArticleId { get; set; }
        public string Provider { get; set; }

        public Article Article { get; set; }
    }
}