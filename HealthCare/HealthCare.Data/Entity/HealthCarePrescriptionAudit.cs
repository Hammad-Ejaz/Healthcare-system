using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity;

public partial class HealthCarePrescriptionAudit
{
    public int Id { get; set; }

    public string OperationType { get; set; }

    public int RowId { get; set; }

    public int? UserId { get; set; }

    public int? OldPatientId { get; set; }

    public int? OldDoctorId { get; set; }

    public DateTime? OldDatePrescribed { get; set; }

    public string OldMedication { get; set; }

    public string OldDosage { get; set; }

    public string OldInstructions { get; set; }

    public bool? OldActive { get; set; }

    public int? NewPatientId { get; set; }

    public int? NewDoctorId { get; set; }

    public DateTime? NewDatePrescribed { get; set; }

    public string NewMedication { get; set; }

    public string NewDosage { get; set; }

    public string NewInstructions { get; set; }

    public bool? NewActive { get; set; }

    public DateTime? AuditDate { get; set; }

    public virtual HealthCarePrescription Row { get; set; }
}
