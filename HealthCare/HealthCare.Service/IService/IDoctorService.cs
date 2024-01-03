using HealthCare.Data.Entity;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IDoctorService
    {
        void AddDoctor(HealthcareDoctor user);
        Task<List<DoctorViewModel>> GetDoctorBySearchText(string searchText);
        Task<List<DoctorViewModel>> GetAllDoctors();
        Task<DoctorViewModel> GetDoctorByDoctorId(int doctorId);
        Task<HealthcareDoctor> GetDoctorByUserId(int userId);


    }
}
