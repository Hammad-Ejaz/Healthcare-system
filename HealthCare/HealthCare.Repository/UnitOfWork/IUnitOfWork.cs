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
        IDoctorRepository Doctor { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
