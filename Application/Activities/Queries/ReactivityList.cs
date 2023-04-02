using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
  public class ReactivityList
  {
    public class Query : IRequest<List<Activity>> { }

    public class handler : IRequestHandler<Query, List<Activity>>
    {
      private DataContext _context;
      public handler(DataContext context)
      {
        _context = context;
      }

      public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
      {
        return await _context.Activities.ToListAsync();
      }
    }
  }
}