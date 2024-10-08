﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MpiSchedule.Data;

namespace MpiSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PressController(PressScheduleContext context) : Controller
{
    [HttpGet]
    public async Task<JsonResult> Index(bool includeJobs = false) => includeJobs
        ? Json(await context.Presses.Include(p => p.Jobs).AsNoTracking().ToListAsync())
        : Json(await context.Presses.AsNoTracking().ToListAsync());

    [HttpGet("{pressId:int}")]
    public async Task<IActionResult> GetPress(int pressId, bool loadJobs = false)
    {
        var press = await context.FindPress(pressId, loadJobs);

        if (press is not null)
        {
            return Json(press);
        }

        return NotFound();
    }
}