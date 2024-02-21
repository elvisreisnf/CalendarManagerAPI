using CalendarManager.Application.Command.Responses;
using CalendarManager.Entities.Enum;
using MediatR;

namespace CalendarManager.Application.Command.Requests
{
    public class ChangeEventTypeRequest : IRequest<ChangeEventTypeResponse>
    {
        public int Id { get; set; }
        public EventType Type { get; set; }
    }
}
