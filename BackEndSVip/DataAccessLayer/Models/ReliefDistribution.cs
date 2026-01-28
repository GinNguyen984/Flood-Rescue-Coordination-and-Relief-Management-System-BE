using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ReliefDistribution
{
    public int DistributionId { get; set; }

    public int InventoryTransactionId { get; set; }

    public int ReliefItemId { get; set; }

    public int Quantity { get; set; }

    public string? DistributionStatus { get; set; }

    public DateTime? DistributedAt { get; set; }

    public virtual InventoryTransaction InventoryTransaction { get; set; } = null!;

    public virtual ReliefItem ReliefItem { get; set; } = null!;
}
