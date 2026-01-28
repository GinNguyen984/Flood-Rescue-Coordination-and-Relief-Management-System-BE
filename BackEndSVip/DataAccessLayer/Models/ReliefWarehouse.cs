using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ReliefWarehouse
{
    public int WarehouseId { get; set; }

    public string? WarehouseName { get; set; }

    public string? LocationDescription { get; set; }

    public int AreaId { get; set; }

    public virtual GeographicArea Area { get; set; } = null!;

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<WarehouseInventory> WarehouseInventories { get; set; } = new List<WarehouseInventory>();
}
