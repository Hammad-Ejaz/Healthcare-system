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
    public class AppointmentService : IAppointmentService
    {
        private IUnitOfWork UnitOfWork;

        public AppointmentService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<List<HealthcareAppointment>> GetDoctorAppointments(int doctorId)
        {
            return (await UnitOfWork.Appointment.GetListAsync()).Where(x=> x.DoctorId == doctorId).ToList();
        }

        public async Task<int> AddAppointment(HealthcareAppointment appointment)
        {
            return await UnitOfWork.Appointment.InsertAsync(appointment);
        }
    }
}
