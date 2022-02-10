using System;
using System.Collections.Generic;

namespace Coodesh.Challenge.Query.Queries.Articles.Shared
{
    public class ArticleResponse
    {
        public int Id { get; set; }
        public bool Featured { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string NewsSite { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<LaunchResponse> Launches { get; set; }
        public List<EventResponse> Events { get; set; }
    }

    public class LaunchResponse
    {
        public Guid Id { get; set; }
        public string Provider { get; set; }
    }

    public class EventResponse
    {
        public Guid Id { get; set; }
        public string Provider { get; set; }
    }
}