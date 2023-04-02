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
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var activity = await _context.Activities.FindAsync(request.activity.Id);
        activity.Category = request.activity.Category;
        activity.City = request.activity.City;
        activity.Description = request.activity.Description;

        _context.Update(activity);
        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}