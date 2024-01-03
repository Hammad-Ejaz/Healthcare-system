using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareChat
    {
        public int Id { get; set; }

        public int? FromUserId { get; set; }

        public int? ToUserId { get; set; }

        public string Message { get; set; }

        public DateTime? EnteredDate { get; set; }

        public bool? IsSeen { get; set; }

        public string ImageFile { get; set; }

        public string DocumentFile { get; set; }

        public DateTime? SeenDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Active { get; set; }

        public virtual HealthCareUser FromUser { get; set; }

        public virtual ICollection<HealthCareChatAudit> HealthCareChatAudits { get; set; } = new List<HealthCareChatAudit>();

        public virtual HealthCareUser ToUser { get; set; }
    }
}
