using HealthCare.Repository.IRepository;
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

        int Commit();
        Task<int> CommitAsync();
    }
}
