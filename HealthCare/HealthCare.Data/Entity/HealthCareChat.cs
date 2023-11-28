using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareChat
    {
        public int Id { get; set; }
        public int? FromEmpId { get; set; }
        public int? ToEmpId { get; set; }
        public string Message { get; set; }
        public DateTime? EnteredDate { get; set; }
        public bool? IsSeen { get; set; }
        public string ImageFile { get; set; }
        public string DocumentFile { get; set; }
        public bool? IsDeleteByFromEmp { get; set; }
        public bool? IsDeleteByToEmp { get; set; }
        public DateTime? SeenDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? Active { get; set; }

        public virtual HealthCareUser FromEmp { get; set; }
        public virtual HealthCareUser ToEmp { get; set; }
    }
}
