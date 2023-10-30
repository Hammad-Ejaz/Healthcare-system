using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class StatusTable
    {
        public StatusTable()
        {
            ReviewTableAudits = new HashSet<ReviewTableAudit>();
            ReviewTables = new HashSet<ReviewTable>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<ReviewTableAudit> ReviewTableAudits { get; set; }
        public virtual ICollection<ReviewTable> ReviewTables { get; set; }
    }
}
