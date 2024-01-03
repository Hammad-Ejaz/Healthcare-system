using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    /// <summary>
    /// This class contains the implementation of all the audits functions
    /// </summary>
    public class AuditsService : IAuditsService
    {
        private IUnitOfWork UnitOfWork;

        public AuditsService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task AddAppointmentAudit(HealthcareAppointment appointment, string auditType, int userId)
        {
            if(appointment.Id != 0 && auditType == "UPDATE")
            {
                var oldValue = UnitOfWork.Appointment.GetById(appointment.Id);
                HealthcareAppointmentsAudit audit = new HealthcareAppointmentsAudit()
                {
                    OperationType = auditType,
                    RowId = appointment.Id,
                    OldPatientId = oldValue.PatientId,
                    OldDoctorId = oldValue.DoctorId,
                    OldScheduleId = oldValue.ScheduleId,
                    OldDescription = oldValue.Description,
                    OldImages = oldValue.Images,
                    OldAppointmentDate = oldValue.AppointmentDate,
                    OldIsApproved = oldValue.IsApproved,
                    OldActive = oldValue.Active,
                    NewPatientId = appointment.PatientId,
                    NewDoctorId = appointment.DoctorId,
                    NewScheduleId = appointment.ScheduleId,
                    NewDescription = appointment.Description,
                    NewImages = appointment.Images,
                    NewAppointmentDate = appointment.AppointmentDate,
                    NewIsApproved = appointment.IsApproved,
                    NewActive = appointment.Active,
                    AuditDate = DateTime.Now,
                    UserId = userId
                };
                await UnitOfWork.AppointmentAudit.InsertAsync(audit);
            }
            else
            {
                HealthcareAppointmentsAudit audit = new HealthcareAppointmentsAudit()
                {
                    OperationType = auditType,
                    RowId = appointment.Id,
                    NewPatientId = appointment.PatientId,
                    NewDoctorId = appointment.DoctorId,
                    NewScheduleId = appointment.ScheduleId,
                    NewDescription = appointment.Description,
                    NewImages = appointment.Images,
                    NewAppointmentDate = appointment.AppointmentDate,
                    NewIsApproved = appointment.IsApproved,
                    NewActive = appointment.Active,
                    AuditDate = DateTime.Now,
                    UserId = userId
                };
                await UnitOfWork.AppointmentAudit.InsertAsync(audit);
            }
        }

        public async Task AddChatAudit(HealthCareChat chat, string auditType, int userId)
        {
            if(chat.Id != 0 && auditType == "UPDATE")
            {
                var oldValue = UnitOfWork.Chat.GetById(chat.Id);
                HealthCareChatAudit audit = new HealthCareChatAudit()
                {
                   OperationType = auditType, 
                   RowId = chat.Id,
                   UserId  = userId,
                   OldFromUserId  = oldValue.FromUserId,
                   OldToUserId = oldValue.ToUserId,
                   OldMessage = oldValue.Message,
                   OldEnteredDate  = oldValue.EnteredDate,
                   OldIsSeen  = oldValue.IsSeen,
                   OldImageFile = oldValue.ImageFile,
                   OldDocumentFile = oldValue.DocumentFile,
                   OldSeenDate = oldValue.SeenDate,
                   OldActive = oldValue.Active,
                   NewFromUserId = chat.FromUserId,
                   NewToUserId = chat.ToUserId,
                   NewMessage = chat.Message, 
                   NewEnteredDate = chat.EnteredDate,
                   NewIsSeen = chat.IsSeen,
                   NewImageFile = chat.ImageFile,
                   NewDocumentFile = chat.DocumentFile,
                   NewSeenDate = chat.SeenDate, 
                   NewActive = chat.Active,
                   AuditDate = DateTime.Now
                };
                await UnitOfWork.ChatAudit.InsertAsync(audit);
            }
            else
            {
                HealthCareChatAudit audit = new HealthCareChatAudit()
                {
                    OperationType = auditType,
                   
                    UserId = userId,
                    NewFromUserId = chat.FromUserId,
                    NewToUserId = chat.ToUserId,
                    NewMessage = chat.Message,
                    NewEnteredDate = chat.EnteredDate,
                    NewIsSeen = chat.IsSeen,
                    NewImageFile = chat.ImageFile,
                    NewDocumentFile = chat.DocumentFile,
                    NewSeenDate = chat.SeenDate,
                    NewActive = chat.Active,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.ChatAudit.InsertAsync(audit);
            }

        }
        public async Task AddDoctorAudit(HealthcareDoctor doctor, string auditType, int userId)
        {
            if(doctor.Id != 0 && auditType == "UPDATE")
            {
                var oldValue = UnitOfWork.Doctor.GetById(doctor.Id);
                HealthcareDoctorAudit audit = new HealthcareDoctorAudit()
                {
                    OperationType = auditType, 
                    RowId = oldValue.Id,
                    UserId = userId,
                    OldUserId  = oldValue.UserId,
                    OldActive  = oldValue.Active,
                    OldWorkExperience  = oldValue.WorkExperience?.ToString(),
                    OldMedicalLicenseInfo = oldValue.MedicalLicenseInfo?.ToString(),
                    OldSpecializationId = oldValue.SpecializationId,
                    NewUserId = doctor.UserId,
                    NewActive = doctor.Active,
                    NewWorkExperience = doctor.WorkExperience?.ToString(),
                    NewMedicalLicenseInfo =  doctor.MedicalLicenseInfo?.ToString(),
                    NewSpecializationId = doctor.SpecializationId,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.DoctorAudit.InsertAsync(audit);
            }
            else
            {
                HealthcareDoctorAudit audit = new HealthcareDoctorAudit()
                {
                    UserId = userId,
                    RowId = doctor.Id,
                    OperationType = auditType,
                    NewUserId = doctor.UserId,
                    NewActive = doctor.Active,
                    NewWorkExperience = doctor.WorkExperience?.ToString(),
                    NewMedicalLicenseInfo = doctor.MedicalLicenseInfo?.ToString(),
                    NewSpecializationId = doctor.SpecializationId,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.DoctorAudit.InsertAsync(audit);
            }
        }


        public async Task AddDoctorAvailabilityScheduleAudit(HealthcareDoctorAvailibilitySchedule schedule , string auditType, int userId)
        {
            if(schedule.Id != 0 && auditType == "UPDATE")
            {
                var oldValue = UnitOfWork.DoctorAvailibility.GetById(schedule.Id);
                HealthcareDoctorAvailibilityScheduleAudit audit = new HealthcareDoctorAvailibilityScheduleAudit()
                {
                    OperationType = auditType, 
                    RowId  = schedule.Id,                 
                    UserId = userId,
                    OldDoctorId = oldValue.DoctorId,
                    OldDayOfWeek = oldValue.DayOfWeek,
                    OldTime = oldValue.Time?.ToString(),
                    OldActive = oldValue.Active,
                    NewDoctorId = schedule.DoctorId,
                    NewDayOfWeek = schedule.DayOfWeek,
                    NewTime = schedule.Time?.ToString(),
                    NewActive  = schedule.Active,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.DoctorAvailibilityAudit.InsertAsync(audit);
            }
            else
            {
                HealthcareDoctorAvailibilityScheduleAudit audit = new HealthcareDoctorAvailibilityScheduleAudit()
                {
                    OperationType = auditType,
                    UserId = userId,
                    NewDoctorId = schedule.DoctorId,
                    NewDayOfWeek = schedule.DayOfWeek,
                    NewTime = schedule.Time?.ToString(),
                    NewActive = schedule.Active,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.DoctorAvailibilityAudit.InsertAsync(audit);
            }
        }

        public async Task AddPrescriptionAudit(HealthCarePrescription prescription , string auditType, int userId)
        {
            if (prescription.Id != 0 && auditType == "UPDATE")
            {
                var oldValue = UnitOfWork.Prescription.GetById(prescription.Id);
                HealthCarePrescriptionAudit audit = new HealthCarePrescriptionAudit()
                {
                    OperationType = auditType,
                    RowId = prescription.Id,
                    UserId = userId,
                    OldPatientId = oldValue.PatientId,
                    OldDoctorId =oldValue.DoctorId,
                    OldDatePrescribed = oldValue.DatePrescribed,
                    OldMedication = oldValue.Medication,
                    OldDosage = oldValue.Dosage,
                    OldInstructions = oldValue.Instructions,
                    OldActive = oldValue.Active,
                    NewPatientId = prescription.PatientId,
                    NewDoctorId = prescription.DoctorId,
                    NewDatePrescribed = prescription.DatePrescribed,
                    NewMedication = prescription.Medication,
                    NewDosage = prescription.Dosage,
                    NewInstructions = prescription.Instructions,
                    NewActive = prescription.Active,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.PrescriptionAudit.InsertAsync(audit);
            }
            else
            {
                HealthCarePrescriptionAudit audit = new HealthCarePrescriptionAudit()
                {
                    OperationType = auditType,
                    UserId = userId,
                    RowId = prescription.Id,
                    NewPatientId = prescription.PatientId,
                    NewDoctorId = prescription.DoctorId,
                    NewDatePrescribed = prescription.DatePrescribed,
                    NewMedication = prescription.Medication,
                    NewDosage = prescription.Dosage,
                    NewInstructions = prescription.Instructions,
                    NewActive = prescription.Active,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.PrescriptionAudit.InsertAsync(audit);
            }
        }

        public async Task AddUserAudit(HealthCareUser user, string auditType, int userId)
        {
            if (user.Id != 0 && auditType == "UPDATE")
            {
                var oldValue = UnitOfWork.User.GetById(user.Id);
                HealthCareUserAudit audit = new HealthCareUserAudit()
                {
                    OperationType = auditType,
                    RowId = user.Id,
                    UserId = userId,
                    OldUsername = oldValue.Username,
                    OldPassword = oldValue.Password,
                    OldEmail = oldValue.Email,
                    OldContactNumber = oldValue.ContactNumber,
                    OldActive = oldValue.Active,
                    OldUserTypeId = oldValue.UserTypeId,
                    OldDateOfBirth = oldValue.DateOfBirth,
                    OldGenderId = oldValue.GenderId,
                    NewUsername = user.Username,
                    NewPassword = user.Password,
                    NewEmail = user.Email,
                    NewContactNumber = user.ContactNumber,
                    NewActive = user.Active,
                    NewUserTypeId = user.UserTypeId,
                    NewDateOfBirth = user.DateOfBirth,
                    NewGenderId = user.GenderId,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.UserAudit.InsertAsync(audit);
            }
            else
            {
                HealthCareUserAudit audit = new HealthCareUserAudit()
                {
                    OperationType = auditType,
                    UserId = userId,
                    NewUsername = user.Username,
                    NewPassword = user.Password,
                    NewEmail = user.Email,
                    NewContactNumber = user.ContactNumber,
                    NewActive = user.Active,
                    NewUserTypeId = user.UserTypeId,
                    NewDateOfBirth = user.DateOfBirth,
                    NewGenderId = user.GenderId,
                    AuditDate = DateTime.Now
                };
                await UnitOfWork.UserAudit.InsertAsync(audit);
            }
        }
    }
}
