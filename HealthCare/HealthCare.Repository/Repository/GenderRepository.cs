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
    public class GenderRepository : Repository<HealthCareGender> ,  IGenderRepository  
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;

        public GenderRepository(IDbContextFactory<CamcoDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
