
using CatalystCMS.BAL;
using CatalystCMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CatalystCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest model)
        {
            // Validate user credentials (e.g., check username and password)
            if (_loginService.ValidateUser(model.Username, model.Password))
            {
                // Generate a JWT token
                var token = GenerateToken(model.Username);

                // Return the token to the client
                return Ok(new { model.Username, Token = token });
            }

            return Unauthorized();
        }

        private string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var hmac = new HMACSHA256();
            var secreateKey = Convert.ToBase64String(hmac.Key);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreateKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "CatalystCMS.com",
                audience: "CatalystCMS.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
