using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RescueTeamMember
{
    public int RescueTeamId { get; set; }

    public int UserId { get; set; }

    public string? RoleInTeam { get; set; }

    public virtual RescueTeam RescueTeam { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
