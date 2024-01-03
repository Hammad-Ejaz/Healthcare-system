using HealthCare.Repository;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.IRepository.IAudits;
using HealthCare.Repository.Repository;
using HealthCare.Repository.Repository.Audits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Threading.Tasks;

namespace CamcoTimeClock.Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public UnitOfWork(IDbContextFactory<HealthCareDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        private readonly IDbContextFactory<HealthCareDbContext> _contextFactory;

        
        private IUserRepository _userRepository;

        public IUserRepository User
        {
            get { return _userRepository ??= new UserRepository(_contextFactory); }
        }

        private ILogRepository _logRepository;

        public ILogRepository Log
        {
            get { return _logRepository ??= new LogRepository(_contextFactory); }
        }

        private IDoctorRepository _doctorRepository;

        public IDoctorRepository Doctor
        {
            get { return _doctorRepository ??= new DoctorRepository(_contextFactory); }
        }

        private ISpecializationRepository _specializationRepository;

        public ISpecializationRepository Specialization
        {
            get { return _specializationRepository ??= new SpecializationRepository(_contextFactory); }
        }

        private IGenderRepository _genderRepository;

        public IGenderRepository Gender
        {
            get { return _genderRepository ??= new GenderRepository(_contextFactory); }
        }
        private IAppointmentRepository _appointmentRepository;

        public IAppointmentRepository Appointment
        {
            get { return _appointmentRepository ??= new AppointmentRepository(_contextFactory); }
        }
        
        private IChatRepository _chatRepository;
        public IChatRepository Chat
        {
            get { return _chatRepository ??= new ChatRepository(_contextFactory); }
        }

        private IPrescriptionRepository _prescriptionRepository;
        public IPrescriptionRepository Prescription
        {
            get { return _prescriptionRepository ??= new PrescriptionRepository(_contextFactory); }
        }

        private IDoctorAvailibilityScheduleRepository _doctorAvailibilityScheduleRepository;
        public IDoctorAvailibilityScheduleRepository DoctorAvailibility
        {
            get { return _doctorAvailibilityScheduleRepository ??= new DoctorAvailibilityScheduleRepository(_contextFactory); }

        }





        private IUserAuditRepository _userAuditRepository;

        public IUserAuditRepository UserAudit
        {
            get { return _userAuditRepository ??= new UserAuditRepository(_contextFactory); }
        }


        private IDoctorAuditRepository _doctorAuditRepository;

        public IDoctorAuditRepository DoctorAudit
        {
            get { return _doctorAuditRepository ??= new DoctorAuditRepository(_contextFactory); }
        }

        private IAppointmentAuditRepository _appointmentAuditRepository;

        public IAppointmentAuditRepository AppointmentAudit
        {
            get { return _appointmentAuditRepository ??= new AppointmentAuditRepository(_contextFactory); }
        }

        private IChatAuditRepository _chatAuditRepository;
        public IChatAuditRepository ChatAudit
        {
            get { return _chatAuditRepository ??= new ChatAuditRepository(_contextFactory); }
        }

        private IPrescriptionAuditRepository _prescriptionAuditRepository;
        public IPrescriptionAuditRepository PrescriptionAudit
        {
            get { return _prescriptionAuditRepository ??= new PrescriptionAuditRepository(_contextFactory); }
        }

        private IDoctorAvailibilityScheduleAuditRepository _doctorAvailibilityScheduleAuditRepository;
        public IDoctorAvailibilityScheduleAuditRepository DoctorAvailibilityAudit
        {
            get { return _doctorAvailibilityScheduleAuditRepository ??= new DoctorAvailibilityScheduleAuditRepository(_contextFactory); }

        }


        public int Commit()
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    return _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public async Task<int> CommitAsync()
        {
            using (var _context = _contextFactory.CreateDbContext())
            {
                return await _context.SaveChangesAsync();
            }
        }

        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                {
                    using (var _context = _contextFactory.CreateDbContext())
                    {
                        _context.Dispose();
                    }
                }

            disposed = true;
        }
    }
}
