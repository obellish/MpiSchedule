using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MpiSchedule.Data;

[PrimaryKey(nameof(JobNumber))]
public class PressJob
{
    [RegularExpression(@"^\d{7}(?:[-|\W]\d)?$")]
    [StringLength(15)]
    public string JobNumber { get; set; }

    public string Name { get; set; }

    public Press Press { get; set; }

    public Shift Shift { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    public int Quantity { get; set; }

    public int QuantityRan { get; set; }
}