using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class InventoryTransaction
{
    public int InventoryTransactionId { get; set; }

    public int? WarehouseId { get; set; }

    public int? RescueRequestId { get; set; }

    public string? TransactionType { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? ConfirmedBy { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public string? Note { get; set; }

    public virtual User? ConfirmedByNavigation { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<ReliefDistribution> ReliefDistributions { get; set; } = new List<ReliefDistribution>();

    public virtual RescueRequest? RescueRequest { get; set; }

    public virtual ReliefWarehouse? Warehouse { get; set; }
}
