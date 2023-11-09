using HealthCare.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.IService
{
    public interface IUserService
    {
        Task<int> AddUser(HealthCareUser user);
        Task<HealthCareUser> IsUserExits(HealthCareUser user);
    }
}
