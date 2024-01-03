using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{

    /// <summary>
    /// This interface contains the audits functions of the project
    /// </summary>
    public interface IAuditsService
    {
        /// <summary>
        /// This function is used to audit the data for Appointments
        /// </summary>
        /// <param name="appointment"></param>
        /// <param name="auditType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddAppointmentAudit(HealthcareAppointment appointment, string auditType, int userId);

        /// <summary>
        /// This function is used to audit the data for the Chats
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="auditType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddChatAudit(HealthCareChat chat, string auditType, int userId);

        /// <summary>
        /// This function is used to audit the data for the doctors
        /// </summary>
        /// <param name="doctor"></param>
        /// <param name="auditType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddDoctorAudit(HealthcareDoctor doctor, string auditType, int userId);

        /// <summary>
        /// This function is used to audit the data for the Doctor availability schedule
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="auditType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddDoctorAvailabilityScheduleAudit(HealthcareDoctorAvailibilitySchedule schedule, string auditType, int userId);

        /// <summary>
        /// This function is used to audit the data for the prescriptions
        /// </summary>
        /// <param name="prescription"></param>
        /// <param name="auditType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddPrescriptionAudit(HealthCarePrescription prescription, string auditType, int userId);


        /// <summary>
        /// This function is used to audit the data for the Users
        /// </summary>
        /// <param name="user"></param>
        /// <param name="auditType"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task AddUserAudit(HealthCareUser user, string auditType, int userId);
    }
}
