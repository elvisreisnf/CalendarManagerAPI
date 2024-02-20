using AutoMapper;
using CalendarManager.Entities.DTOs;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorAgenda.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AuthController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto user)
        {
            var existingUser = _context.User
                 .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });


            var token = JwtTokenService.GenerateToken(existingUser);

            existingUser.HidePassword("");
            return Ok(new { User = existingUser,
                Token = token });

        }
    }
}