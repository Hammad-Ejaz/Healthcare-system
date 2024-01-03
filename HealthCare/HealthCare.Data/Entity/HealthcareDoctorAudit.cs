using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthcareDoctorAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public int? OldUserId { get; set; }

    public bool? OldActive { get; set; }

    public string OldWorkExperience { get; set; }

    public string OldMedicalLicenseInfo { get; set; }

    public int? OldSpecializationId { get; set; }

    public int? NewUserId { get; set; }

    public bool? NewActive { get; set; }

    public string NewWorkExperience { get; set; }

    public string NewMedicalLicenseInfo { get; set; }

    public int? NewSpecializationId { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthcareDoctor Row { get; set; }
}
