using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Web.Http;
using JWTAuthDemo.Models;
using JWTAuthDemo.Repository;
using System;

namespace JWTAuthDemo.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IHttpActionResult Login(LoginModel model)
        {
            var user = UserRepository.ValidateUser(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Value.Username),
            new Claim(ClaimTypes.Role, user.Value.Role)
        };

            var token = new JwtSecurityToken(
                issuer: JwtConfig.Issuer,
                audience: JwtConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(JwtConfig.TokenExpirationMinutes),
                signingCredentials: new SigningCredentials(JwtConfig.SigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString, role = user.Value.Role });
        }
    }
}
