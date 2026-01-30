using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RescueShift
{
    public int ShiftId { get; set; }

    public int? AreaId { get; set; }

    public int? OpenedBy { get; set; }

    public DateTime? OpenedAt { get; set; }

    public int? ClosedBy { get; set; }

    public DateTime? ClosedAt { get; set; }

    public string? ShiftStatus { get; set; }

    public virtual GeographicArea? Area { get; set; }

    public virtual User? ClosedByNavigation { get; set; }

    public virtual User? OpenedByNavigation { get; set; }

    public virtual ICollection<RescueAssignment> RescueAssignments { get; set; } = new List<RescueAssignment>();
}
