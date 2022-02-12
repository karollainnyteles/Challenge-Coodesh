using Coodesh.Challenge.Business.Models;
using MediatR;

namespace Coodesh.Challenge.Command.Commands.Articles.Remove
{
    public class RemoveArticleCommand : IRequest<Article>
    {
        public int Id { get; }

        public RemoveArticleCommand(int id)
        {
            Id = id;
        }
    }
}