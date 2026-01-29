using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AuditLog
{
    public int AuditId { get; set; }

    public int? ActorId { get; set; }

    public string? ActorRole { get; set; }

    public string? Action { get; set; }

    public string? EntityName { get; set; }

    public int? EntityId { get; set; }

    public DateTime? ActionAt { get; set; }

    public virtual AppUser? Actor { get; set; }
}
