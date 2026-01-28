using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ReliefItem
{
    public int ReliefItemId { get; set; }

    public string? ItemName { get; set; }

    public string? Unit { get; set; }

    public virtual ICollection<ReliefDistribution> ReliefDistributions { get; set; } = new List<ReliefDistribution>();

    public virtual ICollection<WarehouseInventory> WarehouseInventories { get; set; } = new List<WarehouseInventory>();
}
