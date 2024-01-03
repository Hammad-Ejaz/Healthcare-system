using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareGender
    {
        public int Id { get; set; }

        public string GenderType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Active { get; set; }

        public virtual ICollection<HealthCareGendersAudit> HealthCareGendersAudits { get; set; } = new List<HealthCareGendersAudit>();

        public virtual ICollection<HealthCareUser> HealthCareUsers { get; set; } = new List<HealthCareUser>();
    }
}
