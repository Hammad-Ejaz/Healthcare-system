using HealthCare.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IDoctorAvailibilityScheduleService
    {
        Task<List<HealthcareDoctorAvailibilitySchedule>> GetDoctorAvailibityByDoctorId(int doctorId);
        Task<int> GetScheduleIdByDoctorIdAndDate(int doctorId, DateTime date);
    }
}
