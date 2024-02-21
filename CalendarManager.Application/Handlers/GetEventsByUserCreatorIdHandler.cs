using AutoMapper;
using CalendarManager.Application.Query.Requests;
using CalendarManager.Application.Query.Responses;
using CalendarManager.Entities.DTOs;
using CalendarManager.Infraestructure.Context;
using MediatR;

namespace CalendarManager.Application.Handlers
{
    public class GetEventsByUserCreatorIdHandler : IRequestHandler<GetEventsByUserCreatorIdRequest, GetEventsByUserCreatorIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetEventsByUserCreatorIdHandler(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<GetEventsByUserCreatorIdResponse> Handle(GetEventsByUserCreatorIdRequest request, CancellationToken cancellationToken)
        {
            var eventList = _context.Event.
                Where(x => x.UserCreatorId == request.UserCreatorId || 
                x.Participants.Contains(request.UserCreatorId.ToString()))
                .ToList()
                .RemoveAll(x => x.Status == false);
                
            if (eventList == null)
            {
                throw new NotImplementedException("Nao existem eventos para este usuário");
            }

            var list = _mapper.Map<List<EventDto>>(eventList);

            return Task.FromResult(new GetEventsByUserCreatorIdResponse {Events = list });
        } 
    }

}
