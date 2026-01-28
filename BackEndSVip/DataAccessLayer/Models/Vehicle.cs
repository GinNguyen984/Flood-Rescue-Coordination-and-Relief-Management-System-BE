using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string? VehicleName { get; set; }

    public string? VehicleType { get; set; }

    public string? VehicleStatus { get; set; }

    public virtual ICollection<RescueTeam> RescueTeams { get; set; } = new List<RescueTeam>();
}
