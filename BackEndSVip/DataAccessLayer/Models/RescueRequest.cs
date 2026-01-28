using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class RescueRequest
{
    public int RescueRequestId { get; set; }

    public int CitizenUserId { get; set; }

    public string? RequestType { get; set; }

    public string? ContactPhone { get; set; }

    public decimal? LocationLat { get; set; }

    public decimal? LocationLng { get; set; }

    public int AreaId { get; set; }

    public int UrgencyLevelId { get; set; }

    public int StatusId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public virtual GeographicArea Area { get; set; } = null!;

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual User CitizenUser { get; set; } = null!;

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<RequestLog> RequestLogs { get; set; } = new List<RequestLog>();

    public virtual ICollection<RequestVerification> RequestVerifications { get; set; } = new List<RequestVerification>();

    public virtual ICollection<RescueAssignment> RescueAssignments { get; set; } = new List<RescueAssignment>();

    public virtual RequestStatus Status { get; set; } = null!;

    public virtual UrgencyLevel UrgencyLevel { get; set; } = null!;
}
