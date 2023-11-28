using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareAppointment
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? ScheduleId { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual HealthcareDoctor Doctor { get; set; }
        public virtual HealthCareUser Patient { get; set; }
        public virtual HealthcareDoctorAvailibilitySchedule Schedule { get; set; }
    }
}
