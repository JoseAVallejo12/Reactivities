using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

      // MediatR Service config
      services.AddMediatR(typeof(ReactivityList.Query));
      services.AddMediatR(typeof(ReactivityCreate.Command));
      services.AddAutoMapper(typeof(MappingProfiles).Assembly);
      services.AddDbContext<DataContext>(opt =>
      {
        opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
      });

      return services;

    }
  }
}