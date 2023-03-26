using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/v1/activities")]
  public class ActivitiesController : ControllerBase
  {
    [HttpGet]
    public Task GetActivities()
    {
      return Task.CompletedTask;
    }

  }
}