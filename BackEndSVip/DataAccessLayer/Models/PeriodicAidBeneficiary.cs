using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PeriodicAidBeneficiary
{
    public int BeneficiaryId { get; set; }

    public int? CampaignId { get; set; }

    public int? CitizenUserId { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? AreaId { get; set; }

    public int? HouseholdSize { get; set; }

    public string? TargetGroup { get; set; }

    public int? PriorityLevel { get; set; }

    public string? Status { get; set; }

    public int? SelectedByAdminId { get; set; }

    public DateTime? SelectedAt { get; set; }

    public virtual GeographicArea? Area { get; set; }

    public virtual PeriodicAidCampaign? Campaign { get; set; }

    public virtual User? CitizenUser { get; set; }

    public virtual ICollection<PeriodicAidDistributionDetail> PeriodicAidDistributionDetails { get; set; } = new List<PeriodicAidDistributionDetail>();

    public virtual User? SelectedByAdmin { get; set; }
}
