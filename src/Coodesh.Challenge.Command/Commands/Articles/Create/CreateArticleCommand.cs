using MediatR;
using System;
using System.Collections.Generic;

namespace Coodesh.Challenge.Command.Commands.Articles.Create
{
    public class CreateArticleCommand : IRequest<CreateArticleResponse>
    {
        public bool Featured { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string NewsSite { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public List<CreateLaunchResponse> Launches { get; set; }
        public List<CreateEventResponse> Events { get; set; }
    }
}