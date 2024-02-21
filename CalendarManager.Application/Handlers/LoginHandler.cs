using AutoMapper;
using CalendarManager.Application.Command.Requests;
using CalendarManager.Application.Command.Responses;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Application.CommandHandler
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public LoginHandler(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var existingUser = _context.User
            .FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);

            if (existingUser == null)
                return Task.FromResult(new LoginResponse { Message = "Usuário incorreto ou inexistente" });

            var token = JwtTokenService.GenerateToken(existingUser);

            return Task.FromResult(new LoginResponse { 
                Id = existingUser.Id,
                Username = existingUser.Username,
                Token = token,
                Message = "Login efetuado com sucesso"
            });
        }
    }
}
