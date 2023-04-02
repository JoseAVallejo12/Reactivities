using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Activities
{
  public static class ActivitiesServicesExtensions
  {
    public static void AddApplicationLayer(this IServiceCollection service)
    {
      service.AddMediatR(Assembly.GetExecutingAssembly());

    }
  }
}