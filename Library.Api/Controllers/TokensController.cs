using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Core.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
       
        public TokensController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync(LoginRequestDto login)
        {
            var user = await ValidateUserAsync(login);
            if (user.Item1)
            {
                var token = GenerateToken(user.Item2);
                return Ok(new { token }); 
            }
            return NotFound("User not macth");
        }

        private async Task<(bool,User)> ValidateUserAsync(LoginRequestDto login)
        {
            var users = await  _unitOfWork._userRepository.GetAllAsync(x => x.Email == login.Email && x.Password == login.Password);
            var user = users.FirstOrDefault();
            if (user is null) return (false, null);
            return (true,user);
            
        }


        private string GenerateToken(User user)
        {
            //Header
            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signInCredential = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signInCredential);



            //Claims, en los claims son la informacion que nosotros queremos validar, o queremos agregarcelo al cuerpo del mensaje, las caracteristicas de los usuarios 
            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,  string.Concat(user.FirstName," ",user.FirstSurname)),
                //new Claim("UserId", user.UserId.ToString()),
                new Claim(ClaimTypes.Role,  user.RoleId.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
               _configuration["Authentication:Issuer"],
               _configuration["Authentication:Audience"],
               claims,
               DateTime.Now,
               DateTime.UtcNow.AddSeconds(30)
            );


            //Signature
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
