using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RequestStatus
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public string? Description { get; set; }

    public bool? IsFinal { get; set; }

    public virtual ICollection<RescueRequest> RescueRequests { get; set; } = new List<RescueRequest>();
}
