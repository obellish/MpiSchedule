using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MpiSchedule.Client.Models;

namespace MpiSchedule.Data;

[Index(nameof(Id), nameof(JobNumber), IsUnique = true)]
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

    [JsonIgnore]
    public Press Press { get; set; } = default!;

    public int PressId { get; set; }

    public Shift Shift { get; set; }

    public JobType Type { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }

    public int Quantity { get; set; }

    public int QuantityRan { get; set; }

    public DateTime ReceivedOrder { get; set; }

    [MaxLength(7)]
    public string? WipItemNumber { get; set; }

    [MaxLength(7)]
    public string? FinishedItemNumber { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }
}