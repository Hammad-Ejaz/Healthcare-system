using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class PaymentTable
    {
        public int PaymentId { get; set; }
        public int? PatientUserId { get; set; }
        public int? ProviderId { get; set; }
        public decimal? Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable PatientUser { get; set; }
        public virtual HealthcareProviderTable Provider { get; set; }
    }
}
