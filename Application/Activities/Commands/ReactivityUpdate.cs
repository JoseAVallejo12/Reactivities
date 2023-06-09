using AutoMapper;
using Domain;
using MediatR;
using Persistence;
namespace Application.Activities.Commands
{
  public class ReactivityUpdate
  {
    public class Command : IRequest
    {
      public Activity activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var activity = await _context.Activities.FindAsync(request.activity.Id);
        _mapper.Map(request.activity, activity);

        _context.Update(activity);
        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}