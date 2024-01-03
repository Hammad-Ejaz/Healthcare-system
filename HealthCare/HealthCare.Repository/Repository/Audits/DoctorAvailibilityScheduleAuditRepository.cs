using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.IRepository.IAudits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Repository.Repository.Audits
{
    public class DoctorAvailibilityScheduleAuditRepository : Repository<HealthcareDoctorAvailibilityScheduleAudit>, IDoctorAvailibilityScheduleAuditRepository
    {
        private readonly IDbContextFactory<HealthCareDbContext> _contextFactory;

        public DoctorAvailibilityScheduleAuditRepository(IDbContextFactory<HealthCareDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
