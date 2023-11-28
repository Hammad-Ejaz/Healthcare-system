using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareGender
    {
        public HealthCareGender()
        {
            HealthCareUsers = new HashSet<HealthCareUser>();
        }

        public int Id { get; set; }
        public string GenderType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<HealthCareUser> HealthCareUsers { get; set; }
    }
}
