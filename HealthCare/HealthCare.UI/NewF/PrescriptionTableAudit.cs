using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class PrescriptionTableAudit
    {
        public int AuditId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public DateTime? DatePrescribed { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public int? OldPatientUserId { get; set; }
        public int? OldProviderId { get; set; }
        public DateTime? OldDatePrescribed { get; set; }
        public string OldMedication { get; set; }
        public string OldDosage { get; set; }
        public string OldInstructions { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable OldPatientUser { get; set; }
        public virtual HealthcareProviderTable OldProvider { get; set; }
        public virtual UserTable User { get; set; }
    }
}
