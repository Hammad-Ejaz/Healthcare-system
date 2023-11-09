using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class HealthCareDoctorSpecialization
    {
        public HealthCareDoctorSpecialization()
        {
            HealthcareDoctors = new HashSet<HealthcareDoctor>();
            HealthcareProviderTables = new HashSet<HealthcareProviderTable>();
        }

        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<HealthcareDoctor> HealthcareDoctors { get; set; }
        public virtual ICollection<HealthcareProviderTable> HealthcareProviderTables { get; set; }
    }
}
