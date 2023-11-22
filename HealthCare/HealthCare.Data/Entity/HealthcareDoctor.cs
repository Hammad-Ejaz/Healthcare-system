using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareDoctor
    {
        public HealthcareDoctor()
        {
            HealthCarePrescriptions = new HashSet<HealthCarePrescription>();
            HealthcareAppointments = new HashSet<HealthcareAppointment>();
            HealthcareDoctorAvailibilitySchedules = new HashSet<HealthcareDoctorAvailibilitySchedule>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? WorkExperience { get; set; }
        public long? MedicalLicenseInfo { get; set; }
        public int? SpecializationId { get; set; }

        public virtual HealthCareDoctorSpecialization Specialization { get; set; }
        public virtual HealthCareUser User { get; set; }
        public virtual ICollection<HealthCarePrescription> HealthCarePrescriptions { get; set; }
        public virtual ICollection<HealthcareAppointment> HealthcareAppointments { get; set; }
        public virtual ICollection<HealthcareDoctorAvailibilitySchedule> HealthcareDoctorAvailibilitySchedules { get; set; }
    }
}
