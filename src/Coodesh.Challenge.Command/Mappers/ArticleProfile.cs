using AutoMapper;
using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Command.Articles.Create;
using Coodesh.Challenge.Command.Articles.Update;

namespace Coodesh.Challenge.Command.Mappers
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<CreateArticleCommand, Article>();
            CreateMap<UpdateArticleCommand, Article>();

            CreateMap<Article, CreateArticleResponse>().ReverseMap();
            CreateMap<Launch, CreateLaunchResponse>().ReverseMap();
            CreateMap<Event, CreateEventResponse>().ReverseMap();

            CreateMap<UpdateEventCommand, Event>().ReverseMap();
            CreateMap<UpdateLaunchCommand, Launch>().ReverseMap();
        }
    }
}