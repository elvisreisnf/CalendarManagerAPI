using System.ComponentModel.DataAnnotations;
using CalendarManager.Entities.Enum;

namespace CalendarManager.Entities.Entities
{
    public class Event
    {
        public Event(string name, string description, DateTime eventDate, string local, string? participants)
        {
            Name = name;
            Description = description;
            EventDate = eventDate;
            Local = local;
            Participants = participants;
            Status = true;
            Type = string.IsNullOrEmpty(participants) ? EventType.Exclusive : EventType.Shared;
            UserCreatorId = 2;
            CreationDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public DateTime EventDate { get; private set; }

        [Required]
        public string Local { get; private set; }

        public string Participants { get; private set; }

        [Required]
        public bool Status { get; private set; }

        public int UserCreatorId { get; private set; }

        [Required]
        public EventType Type { get; private set; }

        [Required]
        public DateTime CreationDate { get; private set; }

        [Required]
        public DateTime UpdateDate { get; private set; }

        public void Activate() => Status = true;

        public void Disable() => Status = false;

        public void ChangeType(EventType type)
        {
            if (type == EventType.Exclusive)
                Participants = "";

            Type = type;
        }

        public void ChangeParticipants(string participants)
        {
            if (string.IsNullOrWhiteSpace(participants))
                ChangeType(EventType.Exclusive);

            Participants = participants;
        }
    }
}
