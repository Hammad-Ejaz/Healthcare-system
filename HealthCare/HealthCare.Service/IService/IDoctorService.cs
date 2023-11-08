using HealthCare.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IDoctorService
    {
        void AddDoctor(HealthcareProviderTable user);
    }
}
