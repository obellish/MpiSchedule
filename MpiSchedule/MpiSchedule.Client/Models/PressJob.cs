using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MpiSchedule.Client.Models;

public class PressJob
{
    public int Id { get; set; }

    [RegularExpression(@"^\d{7}(?:[-|\W]\d)?$")]
    [StringLength(15)]
    [Required]
    public string JobNumber { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public int PressId { get; set; }

    [JsonIgnore]
    public Press Press { get; set; } = default!;

    public Shift Shift { get; set; }

    public JobType Type { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DueDate { get; set; }

    public int Quantity { get; set; }

    public int QuantityRan { get; set; }

    public DateOnly ReceivedOrder { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    [MaxLength(7)]
    public string WipItemNumber { get; set; } = string.Empty;

    [MaxLength(7)]
    public string FinishedItemNumber { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Notes { get; set; } = string.Empty;

    public bool Completed { get; set; }
}