using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PeriodicAidSupplyPlan
{
    public int SupplyPlanId { get; set; }

    public int? CampaignId { get; set; }

    public int? ReliefItemId { get; set; }

    public int? PlannedQuantity { get; set; }

    public int? ApprovedQuantity { get; set; }

    public int? CreatedByManagerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual PeriodicAidCampaign? Campaign { get; set; }

    public virtual ReliefItem? ReliefItem { get; set; }
}
