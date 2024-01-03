using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthCareUserAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public string OldUsername { get; set; }

    public string OldPassword { get; set; }

    public string OldEmail { get; set; }

    public string OldContactNumber { get; set; }

    public bool? OldActive { get; set; }

    public int? OldUserTypeId { get; set; }

    public DateTime? OldDateOfBirth { get; set; }

    public int? OldGenderId { get; set; }

    public string NewUsername { get; set; }

    public string NewPassword { get; set; }

    public string NewEmail { get; set; }

    public string NewContactNumber { get; set; }

    public bool? NewActive { get; set; }

    public int? NewUserTypeId { get; set; }

    public DateTime? NewDateOfBirth { get; set; }

    public int? NewGenderId { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthCareUser Row { get; set; }
}
