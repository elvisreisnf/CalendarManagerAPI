using AutoMapper;
using CalendarManager.Application.Query.Requests;
using CalendarManager.Application.Query.Responses;
using CalendarManager.Entities.DTOs;
using CalendarManager.Infraestructure.Context;
using MediatR;

namespace CalendarManager.Application.Handlers
{
    public class GetEventsByLoggedUserHandler : IRequestHandler<GetEventsByLoggedUserRequest, GetEventsByLoggedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public GetEventsByLoggedUserHandler(IMapper mapper, ApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<GetEventsByLoggedUserResponse> Handle(GetEventsByLoggedUserRequest request, CancellationToken cancellationToken)
        {
            var userDTO = _context.User.Where(x => x.Username == request.Username).ToList();
            var user = _mapper.Map<UserDto>(userDTO.FirstOrDefault()); 

            var eventList = _context.Event.
                Where(x => x.UserCreatorId == user.Id || 
                x.Participants.Contains(user.Id.ToString()))
                .ToList();
                
            if (eventList == null)
            {
                throw new NotImplementedException("Nao existem eventos para este usuário");
            }

            eventList.RemoveAll(x => x.Status == false);

            var list = _mapper.Map<List<EventDto>>(eventList);

            return Task.FromResult(new GetEventsByLoggedUserResponse {Events = list });
        } 
    }

}
