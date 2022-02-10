using System;
using System.Text.Json.Serialization;

namespace Coodesh.Challenge.Business.Models
{
    public class Launch : Entity<Guid>
    {
        [JsonIgnore]
        public int ArticleId { get; set; }

        public string Provider { get; set; }

        [JsonIgnore]
        public Article Article { get; set; }
    }
}