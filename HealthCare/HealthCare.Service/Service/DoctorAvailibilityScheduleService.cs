using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class DoctorAvailibilityScheduleService : IDoctorAvailibilityScheduleService
    {
        private IUnitOfWork UnitOfWork;

        public DoctorAvailibilityScheduleService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<List<HealthcareDoctorAvailibilitySchedule>> GetDoctorAvailibityByDoctorId(int doctorId) 
        {
            return (await UnitOfWork.DoctorAvailibility.GetListAsync()).Where(x => x.DoctorId == doctorId).ToList();
        }
        public async Task<int> GetScheduleIdByDoctorIdAndDate(int doctorId , DateTime date)
        {
            return (await UnitOfWork.DoctorAvailibility.SearchAsync(x=> x.DoctorId == doctorId && x.DayOfWeek == date.DayOfWeek.ToString())).Select(x=>x.Id).FirstOrDefault();
        }
    }
}
