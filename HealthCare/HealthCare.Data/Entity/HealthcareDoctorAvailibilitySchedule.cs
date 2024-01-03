using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareDoctorAvailibilitySchedule
    {
        public int Id { get; set; }

        public int? DoctorId { get; set; }

        public string DayOfWeek { get; set; }

        public TimeSpan? Time { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Active { get; set; }

        public virtual HealthcareDoctor Doctor { get; set; }

        public virtual ICollection<HealthcareAppointment> HealthcareAppointments { get; set; } = new List<HealthcareAppointment>();

        public virtual ICollection<HealthcareDoctorAvailibilityScheduleAudit> HealthcareDoctorAvailibilityScheduleAudits { get; set; } = new List<HealthcareDoctorAvailibilityScheduleAudit>();
    }
}
