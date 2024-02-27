using CalendarManager.Application.Command.Responses;
using CalendarManager.Entities.Entities;
using MediatR;

namespace CalendarManager.Application.Command.Requests
{
    public class CreateEventRequest : IRequest<GetEventByCreationUserResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Local { get; set; }
        public string Participants { get; set; }
        public int UserCreatorId { get; private set; }

        public void SetUserCreatorId(int userId)
        {
            UserCreatorId = userId;
        }
    }
}
