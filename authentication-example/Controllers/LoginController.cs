using System;
using Microsoft.AspNetCore.Mvc;
using AuthenticationExample.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AuthenticationExample.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                User.Identity.IsAuthenticated,
                User.Identity.Name,
                Claims = User.Claims.Select(claim => new { claim.Type, claim.Value })
            });
        }


        [HttpPost("request-token")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (request.Password != "demo")
            {
                return BadRequest("Wrong password! Hint: it's 'demo'");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.NameIdentifier, "Håkon Wikene"),
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Role, "Employee"),
                new Claim(ClaimTypes.Role, "Contributor"),
                new Claim(ClaimTypes.StateOrProvince, "Oslo"),
                new Claim(ClaimTypes.Email, "hakon.wikene@itera.no"),
                new Claim(ClaimTypes.Country, "NO"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityConstants.CryptoKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "localhost:5000",
                audience: "localhost:5000",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}