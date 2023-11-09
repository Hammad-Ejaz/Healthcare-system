using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class ProviderHistoryTableAudit
    {
        public int AuditId { get; set; }
        public int? ProviderHistoryId { get; set; }
        public int? ProviderId { get; set; }
        public int? PatientUserId { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public int? OldProviderHistoryId { get; set; }
        public int? OldProviderId { get; set; }
        public int? OldPatientUserId { get; set; }
        public string OldAction { get; set; }
        public string OldDetails { get; set; }
        public DateTime? OldTimestamp { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable OldPatientUser { get; set; }
        public virtual HealthcareProviderTable OldProvider { get; set; }
        public virtual UserTable User { get; set; }
    }
}
