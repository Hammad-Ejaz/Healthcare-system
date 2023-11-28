using HealthCare.Data.Entity;
using HealthCare.Repository;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.Repository;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private List<string> checkData = new List<string>();
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<PrescriptionViewModel> Get1()
        {
            return null;
          //  return _employeeRepository.Get();
        }
        public List<HealthCareChat> Get()
        {
             return _employeeRepository.Get();
        }
    

        public async Task AddDataToList (string data)
        {
            checkData.Add(data);
        }
        public async Task<List<string>> GetDataList()
        {
            return checkData;
        }
    }
}
