using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthCareDoctorSpecializationAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public string OldSpecialization { get; set; }

    public string OldDetail { get; set; }

    public bool? OldActive { get; set; }

    public string NewSpecialization { get; set; }

    public string NewDetail { get; set; }

    public bool? NewActive { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthCareDoctorSpecialization Row { get; set; }
}
