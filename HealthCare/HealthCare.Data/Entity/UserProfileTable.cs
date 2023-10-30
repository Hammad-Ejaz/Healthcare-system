using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class UserProfileTable
    {
        public int UserProfileId { get; set; }
        public int? UserId { get; set; }
        public string FullName { get; set; }
        public string MedicalHistory { get; set; }
        public string OtherProfileDetails { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable User { get; set; }
    }
}
