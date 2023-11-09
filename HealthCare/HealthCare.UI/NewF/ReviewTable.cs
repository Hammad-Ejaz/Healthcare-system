using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class ReviewTable
    {
        public int ReviewId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public int? StatusId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable PatientUser { get; set; }
        public virtual HealthcareProviderTable Provider { get; set; }
        public virtual StatusTable Status { get; set; }
    }
}
