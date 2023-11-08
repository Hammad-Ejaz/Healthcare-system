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
    public class SpecializationRepository : Repository<HealthCareDoctorSpecialization>, ISpecializationRepository
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;

        public SpecializationRepository(IDbContextFactory<CamcoDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
