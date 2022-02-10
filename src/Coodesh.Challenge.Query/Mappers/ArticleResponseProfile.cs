using AutoMapper;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Query.Queries.Articles.Shared;

namespace Coodesh.Challenge.Query.Mappers
{
    public class ArticleResponseProfile : Profile
    {
        public ArticleResponseProfile()
        {
            CreateMap<Article, ArticleResponse>();
            CreateMap<Launch, LaunchResponse>();
            CreateMap<Event, EventResponse>();
        }
    }
}