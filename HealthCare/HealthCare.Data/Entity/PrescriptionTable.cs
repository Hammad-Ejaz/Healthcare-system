using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class PrescriptionTable
    {
        public int PrescriptionId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public DateTime? DatePrescribed { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable PatientUser { get; set; }
        public virtual HealthcareProviderTable Provider { get; set; }
    }
}
