using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthCareChatAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public int? OldFromUserId { get; set; }

    public int? OldToUserId { get; set; }

    public string OldMessage { get; set; }

    public DateTime? OldEnteredDate { get; set; }

    public bool? OldIsSeen { get; set; }

    public string OldImageFile { get; set; }

    public string OldDocumentFile { get; set; }

    public DateTime? OldSeenDate { get; set; }

    public bool? OldActive { get; set; }

    public int? NewFromUserId { get; set; }

    public int? NewToUserId { get; set; }

    public string NewMessage { get; set; }

    public DateTime? NewEnteredDate { get; set; }

    public bool? NewIsSeen { get; set; }

    public string NewImageFile { get; set; }

    public string NewDocumentFile { get; set; }

    public DateTime? NewSeenDate { get; set; }

    public bool? NewActive { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthCareChat Row { get; set; }
}
