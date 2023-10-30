using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class UserProfileTableAudit
    {
        public int AuditId { get; set; }
        public int? UserProfileId { get; set; }
        public string FullName { get; set; }
        public string MedicalHistory { get; set; }
        public string OtherProfileDetails { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public int? UserId { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public string OldFullName { get; set; }
        public string OldMedicalHistory { get; set; }
        public string OldOtherProfileDetails { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable User { get; set; }
    }
}
