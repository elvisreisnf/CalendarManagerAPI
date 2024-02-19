using AutoMapper;
using CalendarManager.Application.Command;
using CalendarManager.Entities.DTOs;
using CalendarManager.Entities.Entities;
using CalendarManager.Entities.Enum;

namespace CalendarManager.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<CreateEventCommand, Event>().ForMember(dest => dest.Type, opt => opt.Ignore());
            CreateMap<EventType, short>().ConvertUsing(e => (short)e);
            CreateMap<short, EventType>().ConvertUsing(s => (EventType)s);
        }
    }

}
