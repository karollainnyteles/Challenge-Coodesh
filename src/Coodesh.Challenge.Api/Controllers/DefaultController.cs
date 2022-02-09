using Microsoft.AspNetCore.Mvc;
using System;

namespace Coodesh.Challenge.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok($"Back-end Challenge {DateTime.Now.Year} 🏅 - Space Flight News");
        }
    }
}