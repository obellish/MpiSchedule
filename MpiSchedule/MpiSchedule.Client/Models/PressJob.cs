using System;

namespace MpiSchedule.Client.Models;

public class PressJob
{
    public string JobNumber { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public Shift Shift { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    public int Quantity { get; set; }

    public int QuantityRan { get; set; }
}