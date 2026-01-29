using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RequestLog
{
    public int LogId { get; set; }

    public int? RescueRequestId { get; set; }

    public string? Action { get; set; }

    public int? PerformedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual AppUser? PerformedByNavigation { get; set; }

    public virtual RescueRequest? RescueRequest { get; set; }
}
