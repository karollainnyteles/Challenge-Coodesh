using Coodesh.Challenge.Business.Models;
using Coodesh.Challenge.Business.Parameters;
using Coodesh.Challenge.Query.Queries.Articles.Find;
using Coodesh.Challenge.Query.Queries.Articles.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista todos os artigos da base de dados, utilizando paginação
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Article>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAsync([FromQuery] PaginationParameters parameters)
        {
            var response = await _mediator.Send(new FindArticlesQuery(parameters));
            return Ok(response);
        }

        /// <summary>
        /// Obtém a informação somente de um artigo
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Article), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetArticleByIdQuery(id));

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Adiciona um novo artigo
        /// </summary>
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        /// <summary>
        /// Atualiza um artigo baseado no id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Remove um artigo baseado no id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}