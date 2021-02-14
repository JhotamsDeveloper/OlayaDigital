using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlayaDigital.Core.DTOs;
using OlayaDigital.Core.Entities;
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
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        //private readonly IRepository _postRepository;

        public PostController(IPostService postService,
            IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            #region "De Interés"
                //Forma de traer una clase sin hacer una inyección de dependencia
                //var _posts = new PostRepository().GetPosts();

                //Mapeo Manuel
                //var _postDto = _post.Select(x => new PostDto
                //{
                //    Tittle = x.Tittle,
                //    Description = x.Description,
                //    Url = x.Url,
                //    IdCategory = x.IdCategory,
                //    IdUser = x.IdUser
                //});
            #endregion

            var _post = await _postService.GetPosts();

            //Mapeo con AutoMapper
            var _postMapper = _mapper.Map<IEnumerable<PostDto>>(_post);
            return Ok(_postMapper);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id) {

            var _post = await _postService.GetById(id);

            #region "De Interés"
            //Mapeo Manuel
            //var _postDto = _post.Select(x => new PostDto
            //{
            //    Tittle = x.Tittle,
            //    Description = x.Description,
            //    Url = x.Url,
            //    IdCategory = x.IdCategory,
            //    IdUser = x.IdUser
            //});
            #endregion

            //Mapeo con AutoMapper
            var _postMapper = _mapper.Map<PostDto>(_post);
            return Ok(_postMapper);

        }

    }
}
