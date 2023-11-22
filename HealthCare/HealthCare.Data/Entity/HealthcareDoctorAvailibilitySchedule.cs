using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareDoctorAvailibilitySchedule
    {
        public HealthcareDoctorAvailibilitySchedule()
        {
            HealthcareAppointments = new HashSet<HealthcareAppointment>();
        }

        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan? Time { get; set; }

        public virtual HealthcareDoctor Doctor { get; set; }
        public virtual ICollection<HealthcareAppointment> HealthcareAppointments { get; set; }
    }
}
