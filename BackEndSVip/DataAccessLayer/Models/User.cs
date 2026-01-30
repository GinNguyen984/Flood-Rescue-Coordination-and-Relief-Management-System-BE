using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public int? RoleId { get; set; }

    public int? AreaId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual GeographicArea? Area { get; set; }

    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<InventoryTransaction> InventoryTransactionConfirmedByNavigations { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<InventoryTransaction> InventoryTransactionCreatedByNavigations { get; set; } = new List<InventoryTransaction>();

    public virtual ICollection<PeriodicAidBeneficiary> PeriodicAidBeneficiaryCitizenUsers { get; set; } = new List<PeriodicAidBeneficiary>();

    public virtual ICollection<PeriodicAidBeneficiary> PeriodicAidBeneficiarySelectedByAdmins { get; set; } = new List<PeriodicAidBeneficiary>();

    public virtual ICollection<RequestLog> RequestLogs { get; set; } = new List<RequestLog>();

    public virtual ICollection<RequestVerification> RequestVerifications { get; set; } = new List<RequestVerification>();

    public virtual ICollection<RescueAssignment> RescueAssignments { get; set; } = new List<RescueAssignment>();

    public virtual ICollection<RescueRequest> RescueRequests { get; set; } = new List<RescueRequest>();

    public virtual ICollection<RescueShift> RescueShiftClosedByNavigations { get; set; } = new List<RescueShift>();

    public virtual ICollection<RescueShift> RescueShiftOpenedByNavigations { get; set; } = new List<RescueShift>();

    public virtual ICollection<RescueTeamMember> RescueTeamMembers { get; set; } = new List<RescueTeamMember>();

    public virtual Role? Role { get; set; }
}
