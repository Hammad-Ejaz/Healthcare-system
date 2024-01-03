using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Repository.Repository
{
    public class AppointmentRepository : Repository<HealthcareAppointment>, IAppointmentRepository
    {
        private readonly IDbContextFactory<HealthCareDbContext> _contextFactory;

        public AppointmentRepository(IDbContextFactory<HealthCareDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    
    }
}
