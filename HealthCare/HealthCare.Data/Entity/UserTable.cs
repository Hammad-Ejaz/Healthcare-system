using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class UserTable
    {
        public UserTable()
        {
            AppointmentTableAuditOldPatientUsers = new HashSet<AppointmentTableAudit>();
            AppointmentTableAuditUsers = new HashSet<AppointmentTableAudit>();
            AppointmentTables = new HashSet<AppointmentTable>();
            DiscussionTableAuditOldPatientUsers = new HashSet<DiscussionTableAudit>();
            DiscussionTableAuditUsers = new HashSet<DiscussionTableAudit>();
            DiscussionTables = new HashSet<DiscussionTable>();
            HealthcareProviderTableAudits = new HashSet<HealthcareProviderTableAudit>();
            HealthcareProviderTables = new HashSet<HealthcareProviderTable>();
            NotificationTables = new HashSet<NotificationTable>();
            PaymentTableAuditOldPatientUsers = new HashSet<PaymentTableAudit>();
            PaymentTableAuditUsers = new HashSet<PaymentTableAudit>();
            PaymentTables = new HashSet<PaymentTable>();
            PrescriptionTableAuditOldPatientUsers = new HashSet<PrescriptionTableAudit>();
            PrescriptionTableAuditUsers = new HashSet<PrescriptionTableAudit>();
            PrescriptionTables = new HashSet<PrescriptionTable>();
            ProviderHistoryTableAuditOldPatientUsers = new HashSet<ProviderHistoryTableAudit>();
            ProviderHistoryTableAuditUsers = new HashSet<ProviderHistoryTableAudit>();
            ProviderHistoryTables = new HashSet<ProviderHistoryTable>();
            ReviewTableAuditOldPatientUsers = new HashSet<ReviewTableAudit>();
            ReviewTableAuditUsers = new HashSet<ReviewTableAudit>();
            ReviewTables = new HashSet<ReviewTable>();
            UserProfileTableAudits = new HashSet<UserProfileTableAudit>();
            UserProfileTables = new HashSet<UserProfileTable>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserTypeId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? GenderId { get; set; }

        public virtual HealthCareGender Gender { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<AppointmentTableAudit> AppointmentTableAuditOldPatientUsers { get; set; }
        public virtual ICollection<AppointmentTableAudit> AppointmentTableAuditUsers { get; set; }
        public virtual ICollection<AppointmentTable> AppointmentTables { get; set; }
        public virtual ICollection<DiscussionTableAudit> DiscussionTableAuditOldPatientUsers { get; set; }
        public virtual ICollection<DiscussionTableAudit> DiscussionTableAuditUsers { get; set; }
        public virtual ICollection<DiscussionTable> DiscussionTables { get; set; }
        public virtual ICollection<HealthcareProviderTableAudit> HealthcareProviderTableAudits { get; set; }
        public virtual ICollection<HealthcareProviderTable> HealthcareProviderTables { get; set; }
        public virtual ICollection<NotificationTable> NotificationTables { get; set; }
        public virtual ICollection<PaymentTableAudit> PaymentTableAuditOldPatientUsers { get; set; }
        public virtual ICollection<PaymentTableAudit> PaymentTableAuditUsers { get; set; }
        public virtual ICollection<PaymentTable> PaymentTables { get; set; }
        public virtual ICollection<PrescriptionTableAudit> PrescriptionTableAuditOldPatientUsers { get; set; }
        public virtual ICollection<PrescriptionTableAudit> PrescriptionTableAuditUsers { get; set; }
        public virtual ICollection<PrescriptionTable> PrescriptionTables { get; set; }
        public virtual ICollection<ProviderHistoryTableAudit> ProviderHistoryTableAuditOldPatientUsers { get; set; }
        public virtual ICollection<ProviderHistoryTableAudit> ProviderHistoryTableAuditUsers { get; set; }
        public virtual ICollection<ProviderHistoryTable> ProviderHistoryTables { get; set; }
        public virtual ICollection<ReviewTableAudit> ReviewTableAuditOldPatientUsers { get; set; }
        public virtual ICollection<ReviewTableAudit> ReviewTableAuditUsers { get; set; }
        public virtual ICollection<ReviewTable> ReviewTables { get; set; }
        public virtual ICollection<UserProfileTableAudit> UserProfileTableAudits { get; set; }
        public virtual ICollection<UserProfileTable> UserProfileTables { get; set; }

    }
}
