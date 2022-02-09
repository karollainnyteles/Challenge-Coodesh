using Microsoft.AspNetCore.Mvc;

namespace Coodesh.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        /// <summary>
        /// Listar todos os artigos da base de dados, utilizar o sistema de paginação
        /// </summary>

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Obter a informação somente de um artigo
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Adicionar um novo artigo
        /// </summary>
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        /// <summary>
        /// Atualizar um artigo baseado no id
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Remover um artigo baseado no id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}