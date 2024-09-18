using System;
using System.ComponentModel.DataAnnotations;

namespace MpiSchedule.Data;

public class DetailedPressJob
{
    public int Id { get; set; }

    public PressJob Job { get; set; } = default!;

    public int PressJobId { get; set; }

    [Range(1, 12)]
    public int PressMonth { get; set; }

    public DateTime RequestedShipDate { get; set; }

    public DateTime LeadTimeDate { get; set; }

    public string JobNumber => Job.JobNumber;

    [MaxLength(100)]
    public string Customer { get; set; } = default!;

    public int Quantity => Job.Quantity;

    public DateTime MaterialReceiveDate { get; set; }

    public DateTime ReceivedOrder { get; set; }

    [MaxLength(7)]
    public string WipItemNumber { get; set; } = default!;

    [MaxLength(7)]
    public string FinishedItemNumber { get; set; } = default!;

    [MaxLength(500)]
    public string Notes { get; set; } = default!;
}