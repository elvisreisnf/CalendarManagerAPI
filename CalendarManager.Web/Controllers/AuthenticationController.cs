using CalendarManager.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalendarManager.Web.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequest)
        {
            if (IsValidUser(loginRequest.Username, loginRequest.Password))
            {
                var token = GenerateJwtToken(loginRequest.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        private bool IsValidUser(string username, string password)
        {
            // Aqui, você deve validar as credenciais do usuário de acordo com sua lógica de autenticação.
            // Isso é apenas um exemplo básico e deve ser substituído pela lógica real.

            // Exemplo: Verificar em um banco de dados se o usuário existe e se a senha está correta.
            // Lembre-se de nunca armazenar senhas em texto simples, sempre utilize hash e salt.

            // Retorne true se o usuário for válido, caso contrário, retorne false.
            return (username == "usuario_teste" && password == "senha_teste");
        }

        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpirationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
