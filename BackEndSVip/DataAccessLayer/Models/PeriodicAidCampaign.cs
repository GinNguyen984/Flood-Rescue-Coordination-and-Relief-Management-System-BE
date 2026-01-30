using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PeriodicAidCampaign
{
    public int CampaignId { get; set; }

    public string? CampaignName { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public int? AreaId { get; set; }

    public string? Status { get; set; }

    public int? CreatedByAdminId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<PeriodicAidBeneficiary> PeriodicAidBeneficiaries { get; set; } = new List<PeriodicAidBeneficiary>();

    public virtual ICollection<PeriodicAidDistribution> PeriodicAidDistributions { get; set; } = new List<PeriodicAidDistribution>();

    public virtual ICollection<PeriodicAidSupplyPlan> PeriodicAidSupplyPlans { get; set; } = new List<PeriodicAidSupplyPlan>();
}
