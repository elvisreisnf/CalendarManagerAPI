using CalendarManager.Infraestructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CalendarManager.Application.Utils
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public string GetLoggedUsername()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var username = user.Identity.Name;

            return username;
        }

        public int GetLoggedId()
        {
            var username = GetLoggedUsername();
            var user = _context.User.Where(x => x.Username == username).ToList();

            return user.FirstOrDefault().Id;
        }
    }

}
