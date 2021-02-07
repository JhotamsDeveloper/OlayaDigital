using Microsoft.AspNetCore.Mvc;
using OlayaDigital.Core.Intarfaces;
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
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            //Forma de traer una clase sin hacer una inyección de dependencia
            //var _posts = new PostRepository().GetPosts();

            var _posts = await _postRepository.GetPosts();
            return Ok(_posts);
        }
    }
}
