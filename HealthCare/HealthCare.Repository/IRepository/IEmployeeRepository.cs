using HealthCare.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCare.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        List<ExceptionLog> GetList();
    }
}
