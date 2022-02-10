using System;
using System.Collections.Generic;

namespace Coodesh.Challenge.Business.Models
{
    public class Article : Entity<int>
    {
        public bool Featured { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string NewsSite { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<Launch> Launches { get; set; }
        public List<Event> Events { get; set; }
    }
}