using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Command.Articles.Remove
{
    public class RemoveArticleCommandHandler : IRequestHandler<RemoveArticleCommand, Article>
    {
        private readonly IArticleWriteOnlyRepository _articleWriteOnlyRepository;
        private readonly IArticleReadOnlyRepository _articleReadOnlyRepository;

        public RemoveArticleCommandHandler(IArticleWriteOnlyRepository articleWriteOnlyRepository,
                                           IArticleReadOnlyRepository articleReadOnlyRepository)
        {
            _articleWriteOnlyRepository = articleWriteOnlyRepository;
            _articleReadOnlyRepository = articleReadOnlyRepository;
        }

        public async Task<Article> Handle(RemoveArticleCommand command, CancellationToken cancellationToken)
        {
            var article = await _articleReadOnlyRepository.GetByIdAsync(command.Id);

            if (article != null)
            {
                await _articleWriteOnlyRepository.RemoveAsync(article.Id);
                await _articleWriteOnlyRepository.SaveChangesAsync();
            }

            return article;
        }
    }
}