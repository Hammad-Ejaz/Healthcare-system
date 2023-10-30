using HealthCare.Repository.IRepository;
using HealthCare.Repository.Repository;

namespace HealthCare.UI.AppSettings
{
    public static class AppRepositorySetting
    {
        public static IServiceCollection AppRepository(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}
