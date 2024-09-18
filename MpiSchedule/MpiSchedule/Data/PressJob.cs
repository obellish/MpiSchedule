using System;
using System.ComponentModel.DataAnnotations;
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
    public string JobNumber { get; set; }

    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public Press Press { get; set; }

    public int PressId { get; set; }

    public Shift Shift { get; set; }

    public DateTime Date { get; set; }

    public DateTime DueDate { get; set; }
    
    public int Quantity { get; set; }

    public int QuantityRan { get; set; }

    [Timestamp]
    public byte[] Version { get; set; }
}