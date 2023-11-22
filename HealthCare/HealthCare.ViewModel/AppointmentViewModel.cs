using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public TimeSpan ScheduleTime {get;set;}
        public string ScheduleDay { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}
