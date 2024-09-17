using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MpiSchedule.Data;

namespace MpiSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PressController(PressScheduleContext context, ILogger<PressController> logger) : Controller
{
    [HttpGet]
    public async Task<JsonResult> Index() => Json(await context.Presses.Include(p => p.Jobs).ToListAsync());

    [HttpGet("{pressId}")]
    public async Task<IActionResult> GetPress(int pressId)
    {
        var press = await context.FindPress(pressId, true);

        if (press is not null)
        {
            return Json(press);
        }

        return NotFound();
    }
}