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
using OlayaDigital.Core.Entities;

namespace OlayaDigitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Authentication(UserLogin login)
        {
            //Válidar Usuario
            if (IsvalidUser(login))
            {
                var token = GenerateToken();
                return Ok(new { token });
            };

            return NotFound();
        }

        //Válidar Usuarios desde la base de datos
        private bool IsvalidUser (UserLogin login)
        {
            //......
            return true;
        }

        private string GenerateToken()
        {

            //header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Jhonatan Alejandro Muñoz Serna"),
                new Claim(ClaimTypes.Email, "JhotaMS@Outlook.com"),
                new Claim(ClaimTypes.Role, "Adminstrator")
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