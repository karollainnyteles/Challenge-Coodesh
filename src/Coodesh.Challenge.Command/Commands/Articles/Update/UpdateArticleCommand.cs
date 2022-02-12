using Coodesh.Challenge.Business.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Coodesh.Challenge.Command.Commands.Articles.Update
{
    public class UpdateArticleCommand : IRequest<Article>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public bool Featured { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string NewsSite { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public List<UpdateLaunchCommand> Launches { get; set; }
        public List<UpdateEventCommand> Events { get; set; }
    }
}