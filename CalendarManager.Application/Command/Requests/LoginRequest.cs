using CalendarManager.Application.Command.Responses;
using MediatR;

namespace CalendarManager.Application.Command.Requests
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
