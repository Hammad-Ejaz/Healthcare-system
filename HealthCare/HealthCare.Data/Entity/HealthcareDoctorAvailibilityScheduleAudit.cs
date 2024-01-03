using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthcareDoctorAvailibilityScheduleAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public int? OldDoctorId { get; set; }

    public string OldDayOfWeek { get; set; }

    public string OldTime { get; set; }

    public bool? OldActive { get; set; }

    public int? NewDoctorId { get; set; }

    public string NewDayOfWeek { get; set; }

    public string NewTime { get; set; }

    public bool? NewActive { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthcareDoctorAvailibilitySchedule Row { get; set; }
}
