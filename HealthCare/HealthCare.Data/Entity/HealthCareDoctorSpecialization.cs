using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareDoctorSpecialization
    {
        public HealthCareDoctorSpecialization()
        {
            HealthcareProviderTables = new HashSet<HealthcareProviderTable>();
        }

        public int Id { get; set; }
        public string Specialization { get; set; }
        public string Detail { get; set; }

        public virtual ICollection<HealthcareProviderTable> HealthcareProviderTables { get; set; }
    }
}
