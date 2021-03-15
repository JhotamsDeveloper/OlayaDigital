using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OlayaDigital.Core.CustomEntities;
using OlayaDigital.Core.Entities;
using OlayaDigital.Core.Service;

namespace OlayaDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    

    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserSecurityService _userSecurityService;
        public TokenController(IConfiguration configuration, IUserSecurityService userSecurityService)
        {
            _configuration = configuration;
            _userSecurityService = userSecurityService;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //Válidar Usuario
            var validation = await IsvalidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            };

            return NotFound();
        }

        //Válidar Usuarios desde la base de datos
        private async Task<(bool, User)> IsvalidUser (UserLogin login)
        {
            var _user = await _userSecurityService.GetLoginByCredentials(login);
            return (_user != null, _user);
        }

        private string GenerateToken(User _user)
        {

            //header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, _user.Name),
                new Claim(ClaimTypes.Email, _user.Email),
                new Claim(ClaimTypes.MobilePhone, _user.Phone),
                new Claim(ClaimTypes.Role, _user.Role.ToString()),

            };

            //Playload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now, //Esta Fecha indica cuando empieza a funcionar el token
                DateTime.UtcNow.AddMinutes(10) //Esta Fecha indica cuanto dura el token
            );


            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

            /*Forma de utilizar en token desde PostMan
             Creamos el token y lo utilizamos en el parametro bearer token

            otra forma es ponerlo en el header de postman en key escribiendo authorization
            y en valor ponemos Bearer [token]
             */
        }
    }
}