using Coodesh.Challenge.Business.Contracts.Services;
using Coodesh.Challenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coodesh.Challenge.ClientHttp.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _client;

        public ArticleService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.spaceflightnewsapi.net/");
        }

        public async Task<IEnumerable<Article>> Get(int limit, int skip)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var response = await _client.GetAsync($"v3/articles?_limit={limit}&_sort=id&_start={skip}");
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Article>>(content, options);
        }

        public async Task<int> GetCountAsync()
        {
            var response = await _client.GetAsync("v3/articles/count");
            var content = await response.Content.ReadAsStringAsync();
            return int.Parse(content);
        }
    }
}