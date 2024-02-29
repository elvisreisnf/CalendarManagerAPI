using AutoMapper;
using CalendarManager.Application.Command.Requests;
using CalendarManager.Entities.DTOs;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalendarManager.Web.Controllers
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

        [HttpPost]
        [Route ("/login")]
        public async Task<IActionResult> Login([FromServices] IMediator mediator, [FromBody] LoginRequest command)
        {
            try
            {
                var result = await mediator.Send(command);
                var retorno = Ok(new { success = true, data = new { result } });
                return retorno;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao fazer login", error = ex.Message });
            }
        }
    }
}