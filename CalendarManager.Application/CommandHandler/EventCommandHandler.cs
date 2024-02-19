using AutoMapper;
using CalendarManager.Application.Command;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;

namespace CalendarManager.Application.CommandHandler
{
    public class EventCommandHandler
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EventCommandHandler(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle(CreateEventCommand command)
        {
            var newEvent = _mapper.Map<Event>(command);
            _context.Event.Add(newEvent);
            _context.SaveChanges();
        }

        public void Handle(ActivateEventCommand command)
        {
            var existingEvent = _context.Event.Find(command.Id);
            if (existingEvent != null)
            {
                existingEvent.Activate();
                _context.SaveChanges();
            }
        }

        public void Handle(ChangeEventTypeCommand command)
        {
            var existingEvent = _context.Event.Find(command.Id);
            if (existingEvent != null)
            {
                existingEvent.ChangeType(command.Type);
                _context.SaveChanges();
            }
        }
    }
}
