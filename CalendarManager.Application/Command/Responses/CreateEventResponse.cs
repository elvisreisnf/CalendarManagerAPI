using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Application.Command.Responses
{
    public class GetEventByCreationUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatetionDate { get; set; }
    }
}
