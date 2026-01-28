using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class UrgencyLevel
{
    public int UrgencyLevelId { get; set; }

    public string LevelName { get; set; } = null!;

    public string? Description { get; set; }

    public int? SlaMinutes { get; set; }

    public virtual ICollection<RescueRequest> RescueRequests { get; set; } = new List<RescueRequest>();
}
