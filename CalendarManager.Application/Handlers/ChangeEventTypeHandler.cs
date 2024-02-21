using AutoMapper;
using CalendarManager.Application.Command.Requests;
using CalendarManager.Application.Command.Responses;
using CalendarManager.Infraestructure.Context;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CalendarManager.Application.Handlers
{
    public class ChangeEventTypeHandler : IRequestHandler<ChangeEventTypeRequest, ChangeEventTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ChangeEventTypeHandler(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ChangeEventTypeResponse> Handle(ChangeEventTypeRequest request, CancellationToken cancellationToken)
        {
            var existingEvent = _context.Event.Find(request.Id);

            if (existingEvent == null)
                throw new NotImplementedException();


            if (request.Type == Entities.Enum.EventType.Exclusive)
                existingEvent.ChangeParticipants("");

            existingEvent.ChangeType(request.Type);
            
            _context.SaveChanges();

            return Task.FromResult(new ChangeEventTypeResponse { Id = existingEvent.Id, 
                                                                Type = existingEvent.Type, 
                                                                Message = "Mudança de tipo executada com sucesso",
            });
        }
    }
}
