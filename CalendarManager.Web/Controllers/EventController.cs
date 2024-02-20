using AutoMapper;
using CalendarManager.Application.Command;
using CalendarManager.Entities.DTOs;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Tracing;

namespace GerenciadorAgenda.Controllers
{
    [ApiController]
    [Route("api/events")]
    [Authorize]
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
        public IActionResult CreateEvent([FromBody] CreateEventCommand command)
        {
            var newEvent = _mapper.Map<Event>(command);
            _context.Event.Add(newEvent);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, _mapper.Map<EventDto>(newEvent));
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var existingEvent = _context.Event.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EventDto>(existingEvent));
        }

        [HttpPut("{id}/activate")]
        public IActionResult ActivateEvent(int id)
        {
            var existingEvent = _context.Event.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.Activate();
            _context.SaveChanges();

            return Ok(_mapper.Map<EventDto>(existingEvent));
        }

        [HttpPut("{id}/change-type")]
        public IActionResult ChangeEventType(int id, [FromBody] ChangeEventTypeCommand command)
        {
            var existingEvent = _context.Event.Find(id);
            if (existingEvent == null)
            {
                return NotFound();
            }

            existingEvent.ChangeType(command.Type);
            _context.SaveChanges();

            return Ok(_mapper.Map<EventDto>(existingEvent));
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _context.Event.ToList();
            var eventDtos = _mapper.Map<List<EventDto>>(events);

            return Ok(eventDtos);
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