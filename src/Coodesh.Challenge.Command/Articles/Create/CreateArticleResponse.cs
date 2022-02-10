using System;
using System.Collections.Generic;

namespace Coodesh.Challenge.Command.Articles.Create
{
    public class CreateArticleResponse
    {
        public CreateArticleResponse()
        {
            Launches = new List<CreateLaunchResponse>();
            Events = new List<CreateEventResponse>();
        }

        public int Id { get; set; }
        public bool Featured { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string NewsSite { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<CreateLaunchResponse> Launches { get; set; }
        public List<CreateEventResponse> Events { get; set; }
    }

    public class CreateLaunchResponse
    {
        public string Provider { get; set; }
    }

    public class CreateEventResponse
    {
        public string Provider { get; set; }
    }
}