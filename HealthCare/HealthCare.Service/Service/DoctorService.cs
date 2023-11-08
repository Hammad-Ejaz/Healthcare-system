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
    public class DoctorService : IDoctorService
    {
        private IUnitOfWork UnitOfWork;

        public DoctorService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async void AddDoctor(HealthcareProviderTable user)
        {
            UnitOfWork.Doctor.InsertAsync(user);
        }
    }
}
