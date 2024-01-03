using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IAppointmentService
    {
        Task<List<HealthcareAppointment>> GetDoctorAppointments(int doctorId);
        Task<int> AddAppointment(HealthcareAppointment appointment);
        Task<List<AppointmentViewModel>> GetAppointmentViewModelListByDoctorId(int doctorId);
        Task<HealthcareAppointment> GetAppointmentById(int id);
        Task UpdateAppointment(HealthcareAppointment appointment);
        Task<bool> IsAppointmentAlreadyExsits(int doctorId, int patientId, int scheduleId);
        Task<List<AppointmentViewModel>> GetAppointmentViewModelListByUserId(int userId);
        Task<List<AppointmentViewModel>> GetAppointmentViewModelListByDoctorIdAndDate(int doctorId, DateTime date);
    }
}
