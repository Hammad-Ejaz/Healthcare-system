using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class AppointmentTableAudit
    {
        public int AuditId { get; set; }
        public int? AppointmentId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Reason { get; set; }
        public bool? PrescriptionRefillRequested { get; set; }
        public string OtherRelevantDetails { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public int? OldPatientUserId { get; set; }
        public int? OldProviderId { get; set; }
        public DateTime? OldDate { get; set; }
        public TimeSpan? OldTime { get; set; }
        public string OldReason { get; set; }
        public bool? OldPrescriptionRefillRequested { get; set; }
        public string OldOtherRelevantDetails { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable OldPatientUser { get; set; }
        public virtual HealthcareProviderTable OldProvider { get; set; }
        public virtual UserTable User { get; set; }
    }
}
