using System;
using System.Collections.Generic;

namespace HealthCare.UI.NewF
{
    public partial class NotificationTable
    {
        public int NotificationId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime? Timestamp { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual UserTable User { get; set; }
    }
}
