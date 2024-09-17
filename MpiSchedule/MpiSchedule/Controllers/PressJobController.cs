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
    public async Task<JsonResult> Index() => Json(await context.Jobs.Include(p => p.Press).ToListAsync());

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
    public async Task<OkObjectResult> PatchJob(PressJob job)
    {
        context.Jobs.Attach(job).State = EntityState.Modified;

        return Ok(await context.SaveChangesAsync());
    }
}