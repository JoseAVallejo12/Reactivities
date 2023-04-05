using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
  public class ActivitiesController : BaseApiController
  {
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Activity>>> ListActivity()
    {
      return await Mediator.Send(new ReactivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> ActivityDetails(Guid id)
    {
      return await Mediator.Send(new ReactivityDetails.Query() { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult> CreateActivity(Activity activity)
    {
      return Ok(await Mediator.Send(new ReactivityCreate.Command() { activity = activity }));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Activity>> UpdateActivity(Guid id, Activity activity)
    {
      activity.Id = id;
      return Ok(await Mediator.Send(new ReactivityUpdate.Command() { activity = activity }));
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<Activity>> DeleteActivity(Guid id)
    {
      return Ok(await Mediator.Send(new ReactivityDelete.Command() { Id = id }));
    }

  }
}