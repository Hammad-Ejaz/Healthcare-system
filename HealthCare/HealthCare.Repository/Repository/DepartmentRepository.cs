using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Repository.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;
        private readonly ILogger<DepartmentRepository> _logger;

        public DepartmentRepository(IDbContextFactory<CamcoDbContext> contextFactory,
            ILoggerFactory loggerFactory) : base(contextFactory, loggerFactory)
        {
            _contextFactory = contextFactory;
            _logger = loggerFactory.CreateLogger<DepartmentRepository>();
        }

        public async Task<IEnumerable<Department>> GetListAsync(bool isDelete)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Department
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Name)
                    .ToListAsync();
            }
        }

        public override async Task<int> InsertAsync(Department department)
        {
            await Task.Run(() => throw new InvalidOperationException("The method don't user for the services"));
            return 0;
        }

        public  async Task<long> InsertDepartmentAsync(Department department)
        {
            long id = 0;

            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    var local = context.Set<Department>().Local
                        .FirstOrDefault(x => x.GetType().GetProperty("Id").Equals(department.GetType().GetProperty("Id")));

                    if (local != null)
                        context.Entry(local).State = EntityState.Detached;

                    context.Entry(department).State = EntityState.Modified;

                    await context.Set<Department>().AddAsync(department);
                    await context.SaveChangesAsync();

                    id = (long)department.GetType().GetProperty("Id").GetValue(department, null);
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.ToUpper().Contains("VIOLATION OF UNIQUE KEY"))
                {
                    _logger.LogError("Duplicate unique key");
                }
                else
                {
                    _logger.LogError("OTHER ERROR " + ex.Message);
                }
            }

            return id;
        }
    }
}
