using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RescueTeam
{
    public int RescueTeamId { get; set; }

    public string? TeamName { get; set; }

    public string? ContactPhone { get; set; }

    public int? AreaId { get; set; }

    public string? Status { get; set; }

    public virtual GeographicArea? Area { get; set; }

    public virtual ICollection<PeriodicAidDistribution> PeriodicAidDistributions { get; set; } = new List<PeriodicAidDistribution>();

    public virtual ICollection<RescueAssignment> RescueAssignments { get; set; } = new List<RescueAssignment>();

    public virtual ICollection<RescueTeamMember> RescueTeamMembers { get; set; } = new List<RescueTeamMember>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
