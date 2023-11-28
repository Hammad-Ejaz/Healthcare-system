using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
        public async Task<HealthcareAppointment> GetAppointmentById(int id)
        {
            return await UnitOfWork.Appointment.GetByIdAsync(id);
        }
        public async Task UpdateAppointment(HealthcareAppointment appointment)
        {
             await UnitOfWork.Appointment.UpdateAsync(appointment);
        }
        public async Task<List<AppointmentViewModel>> GetUnApprovedAppointmentViewModelListByDoctorId(int doctorId)
        {
            var Appointments = await UnitOfWork.Appointment.GetListAsync();
            var unApprovedAppointments = Appointments.Where(x => x.IsApproved != true && x.DoctorId == doctorId).ToList();
            List<AppointmentViewModel> allUnApporvedAppointments = new();
            var doctors = await UnitOfWork.Doctor.GetListAsync();
            foreach (var obj in  unApprovedAppointments)
            {
                var doctorUserId = doctors.Where(x=> x.Id == obj.DoctorId).Select(x=>x.UserId).FirstOrDefault();
                var schedule = await UnitOfWork.DoctorAvailibility.GetByIdAsync(obj.ScheduleId ?? 0);
                allUnApporvedAppointments.Add(
                    new AppointmentViewModel()
                    {
                        Id = obj.Id,
                        DoctorName = (await UnitOfWork.User.GetByIdAsync(doctorUserId ?? 0)).Username,
                        PatientName = (await UnitOfWork.User.GetByIdAsync(obj.PatientId ?? 0)).Username,
                        ScheduleDate = obj.AppointmentDate.Value.Date,
                        ScheduleDay = schedule.DayOfWeek,
                        ScheduleTime = schedule.Time.Value,
                        Description = obj.Description,
                        IsApproved = obj.IsApproved??false
                    });
            }
            return allUnApporvedAppointments;
        }

        public async Task<bool> IsAppointmentAlreadyExsits(int doctorId , int patientId , int scheduleId)
        {
            var appointment = await UnitOfWork.Appointment.SearchAsync(x=> x.DoctorId == doctorId && x.PatientId == patientId &&  x.ScheduleId == scheduleId);
            return appointment == null;
        }
        
    }
}
