using HealthCare.Repository.IRepository;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
