using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MpiSchedule.Data;

[Index(nameof(PressId), IsUnique = true)]
public class Press
{
    public int PressId { get; set; }

    public string? Name { get; set; }

    public List<PressJob> Jobs { get; set; } = [];
}