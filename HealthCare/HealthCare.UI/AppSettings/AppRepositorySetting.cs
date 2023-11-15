using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.Repository;

namespace HealthCare.UI.AppSettings
{
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

            return services;
        }
    }
}
