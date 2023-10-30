using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCare.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;

        public EmployeeRepository(IDbContextFactory<CamcoDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public List<ExceptionLog> GetList()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var Models = context.ExceptionLogs.ToList();

                return Models;
            }
        }
    }
}
