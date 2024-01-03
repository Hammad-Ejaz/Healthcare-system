using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.IRepository.IAudits;
using HealthCare.Repository.Repository;
using HealthCare.Repository.Repository.Audits;
using Microsoft.CodeAnalysis.Differencing;

namespace HealthCare.UI.AppSettings
{   
    /// <summary>
    /// This class is used to register the repositories
    /// </summary>
    public static class AppRepositorySetting
    {
        public static IServiceCollection AppRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<ISpecializationRepository, SpecializationRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IDoctorAvailibilityScheduleRepository, DoctorAvailibilityScheduleRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            
            // these are the Audits repositories
            services.AddTransient<IDoctorAuditRepository, DoctorAuditRepository>();
            services.AddTransient<IUserAuditRepository, UserAuditRepository>();
            services.AddTransient<IPrescriptionAuditRepository, PrescriptionAuditRepository>();
            services.AddTransient<IChatAuditRepository, ChatAuditRepository>();
            services.AddTransient<IDoctorAvailibilityScheduleAuditRepository, DoctorAvailibilityScheduleAuditRepository>();
            services.AddTransient<IAppointmentAuditRepository, AppointmentAuditRepository>();

            return services;
        }
    }
}
