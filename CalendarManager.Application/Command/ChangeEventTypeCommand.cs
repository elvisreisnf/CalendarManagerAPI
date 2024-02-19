using CalendarManager.Entities.Enum;

namespace CalendarManager.Application.Command
{
    public class ChangeEventTypeCommand
    {
        public int Id { get; set; }
        public EventType Type { get; set; }
    }
}
