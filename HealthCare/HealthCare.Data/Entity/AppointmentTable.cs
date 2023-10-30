using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class AppointmentTable
    {
        public int AppointmentId { get; set; }
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

        public virtual UserTable PatientUser { get; set; }
        public virtual HealthcareProviderTable Provider { get; set; }
    }
}
