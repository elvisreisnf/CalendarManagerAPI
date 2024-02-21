using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Application.Command.Responses
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
