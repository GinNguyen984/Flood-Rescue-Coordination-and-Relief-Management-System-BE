using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RequestVerification
{
    public int VerificationId { get; set; }

    public int? RescueRequestId { get; set; }

    public int? VerifiedBy { get; set; }

    public string? VerificationStatus { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public string? Note { get; set; }

    public virtual RescueRequest? RescueRequest { get; set; }

    public virtual User? VerifiedByNavigation { get; set; }
}
