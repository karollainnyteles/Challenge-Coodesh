using AutoMapper;
using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Command.Articles.Update
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Article>
    {
        private readonly IArticleWriteOnlyRepository _articleWriteOnlyRepository;
        private readonly IArticleReadOnlyRepository _articleReadOnlyRepository;
        private readonly IEventWriteOnlyRepository _eventWriteOnlyRepository;
        private readonly ILaunchWriteOnlyRepository _launchWriteOnlyRepository;
        private readonly IMapper _mapper;

        public UpdateArticleCommandHandler(IArticleWriteOnlyRepository articleWriteOnlyRepository,
                                           IArticleReadOnlyRepository articleReadOnlyRepository,
                                           IMapper mapper,
                                           IEventWriteOnlyRepository eventWriteOnlyRepository,
                                           ILaunchWriteOnlyRepository launchWriteOnlyRepository)
        {
            _articleWriteOnlyRepository = articleWriteOnlyRepository;
            _articleReadOnlyRepository = articleReadOnlyRepository;
            _mapper = mapper;
            _eventWriteOnlyRepository = eventWriteOnlyRepository;
            _launchWriteOnlyRepository = launchWriteOnlyRepository;
        }

        public async Task<Article> Handle(UpdateArticleCommand command, CancellationToken cancellationToken)
        {
            var articleUpdate = await _articleReadOnlyRepository.GetByIdAsync(command.Id);

            if (articleUpdate != null)
            {
                await RemoveEventsAsync(articleUpdate.Events);
                await RemoveLaunchsAsync(articleUpdate.Launches);

                articleUpdate = _mapper.Map<Article>(command);

                await AddEventsAsync(articleUpdate.Events, articleUpdate.Id);
                await AddLaunchsAsync(articleUpdate.Launches, articleUpdate.Id);

                articleUpdate.Launches.Clear();
                articleUpdate.Events.Clear();

                articleUpdate.UpdatedAt = DateTime.Now;
                await _articleWriteOnlyRepository.UpdateAsync(articleUpdate);
                await _articleWriteOnlyRepository.SaveChangesAsync();
            }

            return articleUpdate;
        }

        private async Task RemoveEventsAsync(List<Event> events)
        {
            foreach (var item in events)
            {
                await _eventWriteOnlyRepository.RemoveAsync(item.Id);
            }
        }

        private async Task AddEventsAsync(List<Event> events, int articleId)
        {
            foreach (var item in events)
            {
                item.ArticleId = articleId;
                await _eventWriteOnlyRepository.AddAsync(item);
            }
        }

        private async Task RemoveLaunchsAsync(List<Launch> launchs)
        {
            foreach (var item in launchs)
            {
                await _launchWriteOnlyRepository.RemoveAsync(item.Id);
            }
        }

        private async Task AddLaunchsAsync(List<Launch> launchs, int articleId)
        {
            foreach (var item in launchs)
            {
                item.ArticleId = articleId;
                await _launchWriteOnlyRepository.AddAsync(item);
            }
        }
    }
}