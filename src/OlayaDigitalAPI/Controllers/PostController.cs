using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.DTOs;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Intarfaces;
using OlayaDigital.Core.QueryFilters;
using OlayaDigital.Infrastructure.Interfaces;
using OlayaDigital.Infrastructure.Repositories;
using OlayaDigitalAPI.Responses;
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
        private readonly IUriService _uriService;
        //private readonly IRepository _postRepository;

        public PostController(IPostService postService,
            IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }


        [HttpGet(Name = nameof(GetPosts))]
        public async Task<IActionResult> GetPosts([FromQuery]PostQueryFilter filters)
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

            var _post = _postService.GetPosts(filters);

            //Mapeo con AutoMapper
            var _postMapper = _mapper.Map<IEnumerable<PostDto>>(_post);

            var metadata = new MetaData
            {
                TotalCount = _post.TotalCount,
                PageSize = _post.PageSize,
                CurrentPage = _post.CurrentPage,
                TotalPages = _post.TotalPages,
                HasNexPage = _post.HasNextPage,
                HasPreviousPage = _post.HasPreviousPage,
                HasNexPageUrl = _uriService.GetPostPaginationUri(filters, 
                    Url.RouteUrl(nameof(GetPosts))).ToString(),
                TotalPreviousPageUrl = _uriService.GetPostPaginationUri(filters,
                    Url.RouteUrl(nameof(GetPosts))).ToString()
            };

            var _response = new ApiResponse<IEnumerable<PostDto>>(_postMapper)
            {
                Meta = metadata
            };
            Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(_response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetById(id);
            var postDto = _mapper.Map<PostDto>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            await _postService.InsertPost(post);

            postDto = _mapper.Map<PostDto>(post);

            return Ok(postDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;

            var result = await _postService.UpdatePost(post);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);

            return Ok(result);
        }

    }
}
