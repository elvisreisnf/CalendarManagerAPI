using CalendarManager.Entities.Enum;

namespace CalendarManager.Application.Command.Responses
{
    public class ChangeEventTypeResponse
    {
        public int Id { get; set; }
        public EventType Type { get; set; }
        public string Message { get; set; }
    }
}
