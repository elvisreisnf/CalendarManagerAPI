using AutoMapper;
using CalendarManager.Application.Command.Requests;
using CalendarManager.Application.Query.Requests;
using CalendarManager.Application.Utils;
using CalendarManager.Entities.DTOs;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalendarManager.Web.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public EventController(IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        [Route ("/create")]
        public async Task<IActionResult> CreateEvent([FromServices] IMediator mediator, [FromBody] CreateEventRequest command)
        {
            try
            {
                UserService userService = new UserService(_context, _contextAccessor);
                command.SetUserCreatorId(userService.GetLoggedId());

                var result = await mediator.Send(command);

                return CreatedAtAction(null , result);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = "Erro ao criar o evento", error = ex.Message });
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetEventsByLoggedUser([FromServices] IMediator mediator)
        {
            try
            {
                UserService userService = new UserService(_context, _contextAccessor);
                var username = userService.GetLoggedUsername();

                var request = new GetEventsByLoggedUserRequest
                {
                    Username = username,
                };

                var result = await mediator.Send(request);

                return CreatedAtAction(null, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao criar o evento", error = ex.Message });
            }

        }

        [HttpPut("/change-type")]
        public async Task<IActionResult> ChangeEventTypeAsync([FromServices] IMediator mediator, [FromBody] ChangeEventTypeRequest command)
        {
            try
            {
                UserService userService = new UserService(_context, _contextAccessor);
                command.SetUserCreatorId(userService.GetLoggedId());

                var result = await mediator.Send(command);

                return CreatedAtAction(null, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não Existe evento com este Id", error = ex.Message });
            }
        }
    }
}