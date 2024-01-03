using HealthCare.Repository.IRepository;
using HealthCare.Repository.IRepository.IAudits;
using HealthCare.Repository.Repository;
using System.Threading.Tasks;

namespace CamcoTimeClock.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        IGenderRepository Gender { get; }
        ISpecializationRepository Specialization { get; }
        IDoctorAvailibilityScheduleRepository DoctorAvailibility { get; }
        IAppointmentRepository Appointment { get; }
        IDoctorRepository Doctor { get; }
        IChatRepository Chat { get; }
        IPrescriptionRepository Prescription { get; }
        ILogRepository Log { get; }

        IUserAuditRepository UserAudit { get; }
        IDoctorAvailibilityScheduleAuditRepository DoctorAvailibilityAudit { get; }
        IAppointmentAuditRepository AppointmentAudit { get; }
        IDoctorAuditRepository DoctorAudit { get; }
        IChatAuditRepository ChatAudit { get; }
        IPrescriptionAuditRepository PrescriptionAudit { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
