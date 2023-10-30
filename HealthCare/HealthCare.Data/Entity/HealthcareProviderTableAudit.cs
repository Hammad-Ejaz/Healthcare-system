using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthcareProviderTableAudit
    {
        public int AuditId { get; set; }
        public int? ProviderId { get; set; }
        public int? UserId { get; set; }
        public string Specialties { get; set; }
        public string Location { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }
        public string AuditAction { get; set; }
        public DateTime? AuditTimestamp { get; set; }
        public string OldSpecialties { get; set; }
        public string OldLocation { get; set; }
        public DateTime? OldCreatedAt { get; set; }
        public DateTime? OldUpdatedAt { get; set; }
        public bool? OldActive { get; set; }

        public virtual UserTable User { get; set; }
    }
}
