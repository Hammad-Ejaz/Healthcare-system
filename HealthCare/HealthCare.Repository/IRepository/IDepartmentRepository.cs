using HealthCare.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCare.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetListAsync(bool isDelete);
        Task<long> InsertDepartmentAsync(Department department);
    }
}
