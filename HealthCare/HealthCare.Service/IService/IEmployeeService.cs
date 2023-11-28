using HealthCare.Data.Entity;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IEmployeeService
    {
        Task AddDataToList(string data);
        List<PrescriptionViewModel> Get1();
        List<HealthCareChat> Get();
        Task<List<string>> GetDataList();
    }
}
