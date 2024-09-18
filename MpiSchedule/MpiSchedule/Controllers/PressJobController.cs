using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpiSchedule.Data;

namespace MpiSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PressJobController(PressScheduleContext context) : Controller
{
    [HttpGet]
    public async Task<JsonResult> Index() => Json(await context.Jobs.ToListAsync());

    [HttpGet("{jobId}")]
    public async Task<IActionResult> GetJob(int jobId)
    {
        var job = await context.FindJob(jobId, true);

        if (job is not null)
        {
            return Json(job);
        }

        return NotFound();
    }

    [HttpPatch]
    public async Task<NoContentResult> EditJob(PressJob job)
    {
        context.Jobs.Attach(job).State = EntityState.Modified;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob(PressJob job)
    {
        context.Jobs.Add(job);

        try
        {
            await context.SaveChangesAsync();
        }
        catch
        {
            return new UnsupportedMediaTypeResult();
        }

        return Created();
    }
}