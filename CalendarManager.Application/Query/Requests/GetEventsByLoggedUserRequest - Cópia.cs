using CalendarManager.Application.Command.Responses;
using CalendarManager.Application.Handlers;
using CalendarManager.Application.Query.Responses;
using MediatR;

namespace CalendarManager.Application.Query.Requests
{
    public class GetEventsByLoggedUserRequest : IRequest<GetEventsByLoggedUserResponse>
    {
        public string Username { get; set; }
    }
}
