using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class DiscussionTable
    {
        public int DiscussionId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public string Message { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable PatientUser { get; set; }
        public virtual HealthcareProviderTable Provider { get; set; }
    }
}
