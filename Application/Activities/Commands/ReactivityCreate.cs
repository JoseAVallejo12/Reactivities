using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
  public class ReactivityCreate
  {
    public class Command : IRequest
    {
      public Activity activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        _context.Add(request.activity);
        await _context.SaveChangesAsync();
        return Unit.Value;
      }
    }
  }
}