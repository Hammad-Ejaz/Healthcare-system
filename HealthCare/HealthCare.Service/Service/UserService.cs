using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Service.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork;

        public UserService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<int> AddUser(UserTable user)
        {
              return await UnitOfWork.User.InsertAsync(user);
        }
        public async Task<UserTable> IsUserExits(UserTable user)
        {
            var obj = (await UnitOfWork.User.GetListAsync()).Where(x=> x.Username == user.Username).FirstOrDefault();
            return (obj != null) ? obj : null;
        }
    }
}
