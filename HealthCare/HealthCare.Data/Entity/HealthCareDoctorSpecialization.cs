using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareDoctorSpecialization
    {
        public HealthCareDoctorSpecialization()
        {
            HealthcareDoctors = new HashSet<HealthcareDoctor>();
        }

        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Detail { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<HealthcareDoctor> HealthcareDoctors { get; set; }
    }
}
