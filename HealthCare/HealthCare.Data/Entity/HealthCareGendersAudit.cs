using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthCareGendersAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public string OldGenderType { get; set; }

    public bool? OldActive { get; set; }

    public string NewGenderType { get; set; }

    public bool? NewActive { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthCareGender Row { get; set; }
}
