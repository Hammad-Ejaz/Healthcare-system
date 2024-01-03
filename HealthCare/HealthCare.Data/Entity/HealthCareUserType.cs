using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareUserType
    {
        public int Id { get; set; }

        public string UserType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Active { get; set; }

        public virtual ICollection<HealthCareUserTypesAudit> HealthCareUserTypesAudits { get; set; } = new List<HealthCareUserTypesAudit>();

        public virtual ICollection<HealthCareUser> HealthCareUsers { get; set; } = new List<HealthCareUser>();
    }
}
