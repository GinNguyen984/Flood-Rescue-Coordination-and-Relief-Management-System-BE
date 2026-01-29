using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RescueAssignment
{
    public int AssignmentId { get; set; }

    public int? RescueRequestId { get; set; }

    public int? RescueTeamId { get; set; }

    public int? ShiftId { get; set; }

    public string? AssignmentStatus { get; set; }

    public int? AssignedBy { get; set; }

    public DateTime? AssignedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public string? RejectReason { get; set; }

    public virtual AppUser? AssignedByNavigation { get; set; }

    public virtual RescueRequest? RescueRequest { get; set; }

    public virtual RescueTeam? RescueTeam { get; set; }

    public virtual RescueShift? Shift { get; set; }
}
