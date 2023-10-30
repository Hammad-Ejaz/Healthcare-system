using HealthCare.Data.Entity;
using HealthCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IEmployeeService
    {
        List<ExceptionLog> GetList();
        Task AddDataToList(string data);
        Task<List<string>> GetDataList();
    }
}
