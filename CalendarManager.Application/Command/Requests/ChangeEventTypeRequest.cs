using CalendarManager.Application.Command.Responses;
using CalendarManager.Entities.Enum;
using MediatR;

namespace CalendarManager.Application.Command.Requests
{
    public class ChangeEventTypeRequest : IRequest<ChangeEventTypeResponse>
    {
        public int Id { get; set; }
        public EventType Type { get; set; }
        public string? Participants { get; set; }
        public int UserCreatorId { get; private set; }


        public void SetUserCreatorId(int userId)
        {
            UserCreatorId = userId;
        }
    }

}
