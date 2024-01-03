using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthcareAppointmentsAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? OldPatientId { get; set; }

    public int? OldDoctorId { get; set; }

    public int? OldScheduleId { get; set; }

    public string OldDescription { get; set; }

    public string OldImages { get; set; }

    public DateTime? OldAppointmentDate { get; set; }

    public bool? OldIsApproved { get; set; }

    public bool? OldActive { get; set; }

    public int? NewPatientId { get; set; }

    public int? NewDoctorId { get; set; }

    public int? NewScheduleId { get; set; }

    public string NewDescription { get; set; }

    public string NewImages { get; set; }

    public DateTime? NewAppointmentDate { get; set; }

    public bool? NewIsApproved { get; set; }

    public bool? NewActive { get; set; }

    public DateTime? AuditDate { get; set; }

    public int? UserId { get; set; }

    public virtual HealthcareAppointment Row { get; set; }
}
