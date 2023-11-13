using HealthCare.Repository;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Repository.IRepository;
using HealthCare.Repository.Repository;
using HealthCare.Data.Entity;

namespace HealthCare.Repository.Repository
{
    public class PrescriptionRepository : Repository<HealthCarePrescription> ,  IPrescriptionRepository  
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;
        public PrescriptionRepository(IDbContextFactory<CamcoDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    
    }
}
