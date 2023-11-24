using HealthCare.Data.Entity;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IPrescriptionService
    {
        Task<List<HealthCarePrescription>> GetPrescriptionByDoctorIdAndUserId(int doctorId, int userId);
        Task<List<PrescriptionViewModel>> GetPrescriptionViewModelByDoctorIdAndUserId(int doctorId, int userId);
    }
}
