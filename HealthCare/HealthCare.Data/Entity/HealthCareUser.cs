using System;
using System.Collections.Generic;

namespace HealthCare.Data.Entity
{
    public partial class HealthCareUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Active { get; set; }

        public int? UserTypeId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? GenderId { get; set; }

        public virtual HealthCareGender Gender { get; set; }

        public virtual ICollection<HealthCareChat> HealthCareChatFromUsers { get; set; } = new List<HealthCareChat>();

        public virtual ICollection<HealthCareChat> HealthCareChatToUsers { get; set; } = new List<HealthCareChat>();

        public virtual ICollection<HealthCarePrescription> HealthCarePrescriptions { get; set; } = new List<HealthCarePrescription>();

        public virtual ICollection<HealthCareUserAudit> HealthCareUserAudits { get; set; } = new List<HealthCareUserAudit>();

        public virtual ICollection<HealthcareAppointment> HealthcareAppointments { get; set; } = new List<HealthcareAppointment>();

        public virtual ICollection<HealthcareDoctor> HealthcareDoctors { get; set; } = new List<HealthcareDoctor>();

        public virtual HealthCareUserType UserType { get; set; }
    }
}
