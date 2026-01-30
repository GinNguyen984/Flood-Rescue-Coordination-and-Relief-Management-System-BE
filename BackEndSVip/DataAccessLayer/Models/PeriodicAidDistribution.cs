using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PeriodicAidDistribution
{
    public int DistributionId { get; set; }

    public int? CampaignId { get; set; }

    public int? RescueTeamId { get; set; }

    public DateTime? DistributedAt { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public virtual PeriodicAidCampaign? Campaign { get; set; }

    public virtual ICollection<PeriodicAidDistributionDetail> PeriodicAidDistributionDetails { get; set; } = new List<PeriodicAidDistributionDetail>();

    public virtual RescueTeam? RescueTeam { get; set; }
}
