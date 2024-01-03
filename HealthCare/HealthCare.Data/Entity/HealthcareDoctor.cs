using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareDoctor
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Active { get; set; }

        public int? WorkExperience { get; set; }

        public long? MedicalLicenseInfo { get; set; }

        public int? SpecializationId { get; set; }

        public virtual ICollection<HealthCarePrescription> HealthCarePrescriptions { get; set; } = new List<HealthCarePrescription>();

        public virtual ICollection<HealthcareAppointment> HealthcareAppointments { get; set; } = new List<HealthcareAppointment>();

        public virtual ICollection<HealthcareDoctorAudit> HealthcareDoctorAudits { get; set; } = new List<HealthcareDoctorAudit>();

        public virtual ICollection<HealthcareDoctorAvailibilitySchedule> HealthcareDoctorAvailibilitySchedules { get; set; } = new List<HealthcareDoctorAvailibilitySchedule>();

        public virtual HealthCareDoctorSpecialization Specialization { get; set; }

        public virtual HealthCareUser User { get; set; }
    }
}
