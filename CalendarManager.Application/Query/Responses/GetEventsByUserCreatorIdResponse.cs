using CalendarManager.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Application.Query.Responses
{
    public class GetEventsByUserCreatorIdResponse
    {
        public List<EventDto> Events { get; set; }
    }
}
