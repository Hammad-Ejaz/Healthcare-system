﻿using HealthCare.Service.IService;
using HealthCare.Service.Service;

namespace HealthCare.UI.AppSettings
{
    public static class AppServiceSetting
    {
        public static IServiceCollection AppService(this IServiceCollection services)
        {
            //app services
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IHelperService, HelperService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IFileManager, FileManager>();

            return services;
        }
    }
}
