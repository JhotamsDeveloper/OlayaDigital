using Microsoft.AspNetCore.Mvc;
using OlayaDigital.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlayaDigitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPosts()
        {
            //Forma de traer una clase sin hacer una inyección de dependencia
            var _posts = new PostRepository().GetPosts();

            return Ok(_posts);
        }
    }
}
