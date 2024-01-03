﻿using HealthCare.Data.Entity;
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
    public class AppointmentAuditRepository : Repository<HealthcareAppointmentsAudit>, IAppointmentAuditRepository
    {
        private readonly IDbContextFactory<HealthCareDbContext> _contextFactory;

        public AppointmentAuditRepository(IDbContextFactory<HealthCareDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
