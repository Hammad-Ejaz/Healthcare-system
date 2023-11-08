using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class HelperService : IHelperService
    {
        private IUnitOfWork UnitOfWork;

        public HelperService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<List<HealthCareGender>> GetAllGenders()
        {
            return (await UnitOfWork.Gender.GetListAsync()).ToList();          
        }
        public async Task<List<HealthCareDoctorSpecialization>> GetAllDoctorSpecializations()
        {
            return (await UnitOfWork.Specialization.GetListAsync()).ToList();
        }
    }
}
