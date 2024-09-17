using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MpiSchedule.Client.Models;

public class PressJob
{
    public int Id { get; set; }

    [RegularExpression(@"^\d{7}(?:[-|\W]\d)?$")]
    [StringLength(15)]
    public string JobNumber { get; set; }

    public string Name { get; set; }

    public int PressId { get; set; }

    public Shift Shift { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    public int Quantity { get; set; }

    public int QuantityRan { get; set; }
}