using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class DiscussionTableAudit
    {
        public int AuditId { get; set; }
        public int? DiscussionId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public string Message { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public int? OldPatientUserId { get; set; }
        public int? OldProviderId { get; set; }
        public string OldMessage { get; set; }
        public DateTime? OldTimestamp { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable OldPatientUser { get; set; }
        public virtual HealthcareProviderTable OldProvider { get; set; }
        public virtual UserTable User { get; set; }
    }
}
