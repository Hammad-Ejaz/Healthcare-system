using HealthCare.Data.Entity;
using HealthCare.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HealthCare.Repository.Repository
{
    public class UserRepository : Repository<UserTable> ,  IUserRepository
    {

        private readonly IDbContextFactory<CamcoDbContext> _contextFactory;

        public UserRepository(IDbContextFactory<CamcoDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
