using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpiSchedule.Data;

namespace MpiSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PressController(PressScheduleContext context) : Controller
{
    [HttpGet]
    public async Task<JsonResult> Index() => Json(await context.Presses.Include(p => p.Jobs).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPress(int id = 0)
    {
        var press = await context.Presses.Include(p => p.Jobs).FirstAsync(p => p.PressId == id);

        if (press is not null)
        {
            return Json(press);
        }

        return NotFound();
    }
}
