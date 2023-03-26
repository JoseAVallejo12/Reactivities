using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
  [ApiController]
  [Route("api/v1/activities")]
  public class ActivityController : ControllerBase
  {
    public DataContext _context { get; }
    public ActivityController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Activity>>> ListActivity()
    {
      return await _context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> ActivityDetails(Guid id)
    {
      return await _context.Activities.FindAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Activity>> CreateActivity(Activity activity)
    {
      _context.Activities.Add(activity);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(ActivityDetails), new { id = activity.Id }, activity);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Activity>> UpdateActivity(Guid id, Activity activity)
    {
      if (id != activity.Id)
      {
        return BadRequest();
      }

      _context.Entry(activity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return Ok("Activity updated");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Activity>> DeleteActivity(Guid id)
    {
      _context.Activities.Where(p => p.Id == id).ExecuteDelete();
      await _context.SaveChangesAsync();
      return Ok("Activity deleted");

    }

  }
}