using AutoMapper;
using CalendarManager.Application.Command.Requests;
using CalendarManager.Application.Query.Requests;
using CalendarManager.Entities.DTOs;
using CalendarManager.Infraestructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalendarManager.Web.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public EventController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        [Route ("/create")]
        public async Task<IActionResult> CreateEvent([FromServices] IMediator mediator, [FromBody] CreateEventRequest command)
        {
            try
            {
                var result = await mediator.Send(command);

                return CreatedAtAction(null , result);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = "Erro ao criar o evento", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventsByUserCreatorId([FromServices] IMediator mediator, int id)
        {
            try
            {
                var request = new GetEventsByUserCreatorIdRequest
                {
                    UserCreatorId = id,
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
                var result = await mediator.Send(command);

                return CreatedAtAction(null, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Não Existe evento com este Id", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var existingEvent = _context.Event.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            _context.Event.Remove(existingEvent);
            _context.SaveChanges();

            return NoContent();
        }
    }
}