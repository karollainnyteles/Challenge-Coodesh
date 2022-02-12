using Coodesh.Challenge.Business.Contracts.Repositories;
using Coodesh.Challenge.Business.Contracts.Services;
using Coodesh.Challenge.Business.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Command.Commands.SynchronizationControls.SyncArticles
{
    public class SynchronizationControlCommandHandler : IRequestHandler<SynchronizationControlCommand>
    {
        private readonly ISynchronizationControlReadOnlyRepository _synchronizationControlReadOnlyRepository;
        private readonly ISynchronizationControlWriteOnlyRepository _synchronizationControlWriteOnlyRepository;
        private readonly IArticleService _articleService;
        private readonly IArticleWriteOnlyRepository _articleWriteOnlyRepository;

        public SynchronizationControlCommandHandler(ISynchronizationControlReadOnlyRepository synchronizationControlReadOnlyRepository,
                                                    ISynchronizationControlWriteOnlyRepository synchronizationControlWriteOnlyRepository,
                                                    IArticleService articleService,
                                                    IArticleWriteOnlyRepository articleWriteOnlyRepository)
        {
            _synchronizationControlReadOnlyRepository = synchronizationControlReadOnlyRepository;
            _synchronizationControlWriteOnlyRepository = synchronizationControlWriteOnlyRepository;
            _articleService = articleService;
            _articleWriteOnlyRepository = articleWriteOnlyRepository;
        }

        public async Task<Unit> Handle(SynchronizationControlCommand request, CancellationToken cancellationToken)
        {
            var countArticlesApi = await _articleService.GetCountAsync();
            var lastSync = await _synchronizationControlReadOnlyRepository.GetLast();
            var articlesCount = lastSync?.ArticlesCount;
            var diference = countArticlesApi - articlesCount.GetValueOrDefault();

            var limit = 50;
            var articlesApi = new List<Article>();
            var skip = articlesCount.GetValueOrDefault();
            for (int i = 0; i < diference; i += limit)
            {
                var list = await _articleService.Get(limit, skip + i);
                list.ForEach(a => a.Launches.ForEach(l => l.Id = Guid.NewGuid()));
                list.ForEach(a => a.Events.ForEach(l => l.Id = 0));
                articlesApi.AddRange(list);
            }

            foreach (var item in articlesApi)
            {
                item.Id = 0;
                await _articleWriteOnlyRepository.AddAsync(item);
            }

            await _synchronizationControlWriteOnlyRepository
                .AddAsync(new SynchronizationControl
                {
                    ArticlesCount = countArticlesApi,
                    SynchronizedArticles = diference
                });

            await _articleWriteOnlyRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}