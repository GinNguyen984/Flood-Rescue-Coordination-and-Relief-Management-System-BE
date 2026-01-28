using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RescueTeam
{
    public int RescueTeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string? ContactPhone { get; set; }

    public int AreaId { get; set; }

    public string? Status { get; set; }

    public virtual GeographicArea Area { get; set; } = null!;

    public virtual ICollection<RescueAssignment> RescueAssignments { get; set; } = new List<RescueAssignment>();

    public virtual ICollection<RescueTeamMember> RescueTeamMembers { get; set; } = new List<RescueTeamMember>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
