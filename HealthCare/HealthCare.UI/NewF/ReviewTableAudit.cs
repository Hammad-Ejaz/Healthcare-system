using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class ReviewTableAudit
    {
        public int AuditId { get; set; }
        public int? ReviewId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public int? StatusId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public int? OldPatientUserId { get; set; }
        public int? OldProviderId { get; set; }
        public int? OldStatusId { get; set; }
        public int? OldRating { get; set; }
        public string OldComment { get; set; }
        public DateTime? OldTimestamp { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable OldPatientUser { get; set; }
        public virtual HealthcareProviderTable OldProvider { get; set; }
        public virtual StatusTable OldStatus { get; set; }
        public virtual UserTable User { get; set; }
    }
}
