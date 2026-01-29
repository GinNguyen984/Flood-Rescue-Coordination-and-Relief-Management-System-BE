using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class WarehouseInventory
{
    public int WarehouseId { get; set; }

    public int ReliefItemId { get; set; }

    public int? Quantity { get; set; }

    public virtual ReliefItem ReliefItem { get; set; } = null!;

    public virtual ReliefWarehouse Warehouse { get; set; } = null!;
}
