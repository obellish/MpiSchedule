using System.Collections.Generic;

namespace MpiSchedule.Data;

public class Press
{
    public int PressId { get; set; }

    public string? Name { get; set; }

    public List<PressJob> Jobs { get; set; } = [];
}