using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Attachment
{
    public int AttachmentId { get; set; }

    public int? RescueRequestId { get; set; }

    public string? FileUrl { get; set; }

    public string? FileType { get; set; }

    public DateTime? UploadedAt { get; set; }

    public int? UploadedBy { get; set; }

    public virtual RescueRequest? RescueRequest { get; set; }

    public virtual AppUser? UploadedByNavigation { get; set; }
}
