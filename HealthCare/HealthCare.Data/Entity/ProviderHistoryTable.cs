using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class ProviderHistoryTable
    {
        public int ProviderHistoryId { get; set; }
        public int? ProviderId { get; set; }
        public int? PatientUserId { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable PatientUser { get; set; }
        public virtual HealthcareProviderTable Provider { get; set; }
    }
}
