using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class GeographicArea
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public int? ParentAreaId { get; set; }

    public virtual ICollection<GeographicArea> InverseParentArea { get; set; } = new List<GeographicArea>();

    public virtual GeographicArea? ParentArea { get; set; }

    public virtual ICollection<ReliefWarehouse> ReliefWarehouses { get; set; } = new List<ReliefWarehouse>();

    public virtual ICollection<RescueRequest> RescueRequests { get; set; } = new List<RescueRequest>();

    public virtual ICollection<RescueShift> RescueShifts { get; set; } = new List<RescueShift>();

    public virtual ICollection<RescueTeam> RescueTeams { get; set; } = new List<RescueTeam>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
