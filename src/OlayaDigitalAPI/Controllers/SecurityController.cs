using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OlayaDigital.Core.DTOs;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Service;
using OlayaDigitalAPI.Responses;

namespace OlayaDigitalAPI.Controllers
{
    [Produces("aplication/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUserSecurityService _userSecurityService;
        private readonly IMapper _mapper;

        public SecurityController(IUserSecurityService userSecurityService,
            IMapper mapper)
        {
            _userSecurityService = userSecurityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserSecurityDto userSecurityDto)
        {
            var _security = _mapper.Map<User>(userSecurityDto);
            await _userSecurityService.RegisterUser(_security);

            userSecurityDto = _mapper.Map<UserSecurityDto>(_security);
            var response = new ApiResponse<UserSecurityDto>(userSecurityDto);
            return Ok(response);
        }
    }
}