using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PeriodicAidDistributionDetail
{
    public int DetailId { get; set; }

    public int? DistributionId { get; set; }

    public int? BeneficiaryId { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public virtual PeriodicAidBeneficiary? Beneficiary { get; set; }

    public virtual PeriodicAidDistribution? Distribution { get; set; }
}
