using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStore.Business.Services;
using BookStore.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Api
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration configuration;
        private IUserService userService;

        public TokenController(IConfiguration _configuration, IUserService _userService)
        {
            this.userService = _userService;
            this.configuration = _configuration;
        }

        [HttpPost("Token")]
        public IActionResult GetToken([FromBody]DtoUser model)
        {
            string secretSection = configuration.GetSection("AppSettings").GetSection("Secret").Value;
 
            string token = Generate(new TokenDescriptor
            {
                Claims = new Claim[]
                {
                    new Claim("id", model.UserId.ToString()),
                    new Claim("userName", model.UserName),
                },

                ExpiresValue = DateTime.UtcNow.AddMinutes(5),
                Secret = secretSection
            });

            return new JsonResult(new
            {
                Token = token
            });
        }

        public string Generate(TokenDescriptor descriptor)
        {
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(descriptor.Claims),
                Expires = descriptor.ExpiresValue,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(descriptor.Secret)), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }
    }
}