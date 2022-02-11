using Coodesh.Challenge.Business.Parameters;
using Coodesh.Challenge.Command.Articles.Create;
using Coodesh.Challenge.Command.Articles.Remove;
using Coodesh.Challenge.Command.Articles.Update;
using Coodesh.Challenge.Query.Queries.Articles.Find;
using Coodesh.Challenge.Query.Queries.Articles.GetById;
using Coodesh.Challenge.Query.Queries.Articles.Shared;
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
        [ProducesResponseType(typeof(IEnumerable<ArticleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAsync([FromQuery] PaginationParameters parameters)
        {
            var response = await _mediator.Send(new FindArticlesQuery(parameters));
            return Ok(response);
        }

        /// <summary>
        /// Obtém a informação somente de um artigo
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ArticleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetArticleByIdQuery(id));

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Adiciona um novo artigo
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(CreateArticleResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] CreateArticleCommand command)
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction("GetById", new { response.Id }, response);
        }

        /// <summary>
        /// Atualiza um artigo baseado no id
        /// </summary>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateArticleCommand command)
        {
            command.Id = id;
            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Remove um artigo baseado no id
        /// </summary>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var response = await _mediator.Send(new RemoveArticleCommand(id));

            if (response == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}