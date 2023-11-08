using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;

namespace HealthCare.Repository.Repository
{
    public class DoctorRepository  : Repository<HealthcareProviderTable> ,  IDoctorRepository  
    {
        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;

        public DoctorRepository(IDbContextFactory<CamcoDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }




    }
}
