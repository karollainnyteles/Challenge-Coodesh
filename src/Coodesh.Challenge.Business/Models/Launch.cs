namespace Coodesh.Challenge.Business.Models
{
    public class Launch : Entity
    {
        public int ArticleId { get; set; }
        public string Provider { get; set; }

        public Article Article { get; set; }
    }
}