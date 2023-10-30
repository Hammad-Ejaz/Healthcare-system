using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareProviderTable
    {
        public HealthcareProviderTable()
        {
            AppointmentTableAudits = new HashSet<AppointmentTableAudit>();
            AppointmentTables = new HashSet<AppointmentTable>();
            DiscussionTableAudits = new HashSet<DiscussionTableAudit>();
            DiscussionTables = new HashSet<DiscussionTable>();
            PaymentTableAudits = new HashSet<PaymentTableAudit>();
            PaymentTables = new HashSet<PaymentTable>();
            PrescriptionTableAudits = new HashSet<PrescriptionTableAudit>();
            PrescriptionTables = new HashSet<PrescriptionTable>();
            ProviderHistoryTableAudits = new HashSet<ProviderHistoryTableAudit>();
            ProviderHistoryTables = new HashSet<ProviderHistoryTable>();
            ReviewTableAudits = new HashSet<ReviewTableAudit>();
            ReviewTables = new HashSet<ReviewTable>();
        }

        public int ProviderId { get; set; }
        public int? UserId { get; set; }
        public string Specialties { get; set; }
        public string Location { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable User { get; set; }
        public virtual ICollection<AppointmentTableAudit> AppointmentTableAudits { get; set; }
        public virtual ICollection<AppointmentTable> AppointmentTables { get; set; }
        public virtual ICollection<DiscussionTableAudit> DiscussionTableAudits { get; set; }
        public virtual ICollection<DiscussionTable> DiscussionTables { get; set; }
        public virtual ICollection<PaymentTableAudit> PaymentTableAudits { get; set; }
        public virtual ICollection<PaymentTable> PaymentTables { get; set; }
        public virtual ICollection<PrescriptionTableAudit> PrescriptionTableAudits { get; set; }
        public virtual ICollection<PrescriptionTable> PrescriptionTables { get; set; }
        public virtual ICollection<ProviderHistoryTableAudit> ProviderHistoryTableAudits { get; set; }
        public virtual ICollection<ProviderHistoryTable> ProviderHistoryTables { get; set; }
        public virtual ICollection<ReviewTableAudit> ReviewTableAudits { get; set; }
        public virtual ICollection<ReviewTable> ReviewTables { get; set; }
    }
}
