using AutoMapper;
using CalendarManager.Application.Command.Requests;
using CalendarManager.Application.Command.Responses;
using CalendarManager.Entities.Entities;
using CalendarManager.Infraestructure.Context;
using MediatR;

namespace CalendarManager.Application.CommandHandler
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, GetEventByCreationUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CreateEventHandler(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<GetEventByCreationUserResponse> Handle(CreateEventRequest request, CancellationToken cancellationToken)
        {
            var newEvent = _mapper.Map<Event>(request);

            _context.Event.Add(newEvent);
            _context.SaveChanges();

            var result = new GetEventByCreationUserResponse
            {
                Id = newEvent.Id,
                Name = newEvent.Name,
                CreatetionDate = DateTime.Now,
            };

            return Task.FromResult(result);
        }
    }
}
