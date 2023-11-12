using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCarePrescription
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? DatePrescribed { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public string Instructions { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual HealthcareDoctor Doctor { get; set; }
        public virtual HealthCareUser Patient { get; set; }
    }
}
