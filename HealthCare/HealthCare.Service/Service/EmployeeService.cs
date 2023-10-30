using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.Repository;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        public async Task AddDataToList (string data)
        {
            checkData.Add(data);
        }
        public async Task<List<string>> GetDataList()
        {
            return checkData;
        }
        public List<ExceptionLog> GetList()
        {
            return _employeeRepository.GetList();
                 
            //List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            //foreach(var obj in _employeeRepository.GetList())
            //{
            //    EmployeeViewModel _obj = new EmployeeViewModel();
            //    _obj.FirstName = obj.FirstName;
            //    _obj.LastName = obj.LastName;
            //    _obj.Address =  obj.Address;
            //    employees.Add(_obj);
            //}
            //return employees;
        }
    }
}
