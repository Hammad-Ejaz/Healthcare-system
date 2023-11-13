using CamcoTimeClock.Repository.UnitOfWork;
using HealthCare.Data.Entity;
using HealthCare.Service.IService;
using HealthCare.ViewModels;
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
        public async void UpdateUser(HealthCareUser user)
        {
            await UnitOfWork.User.UpdateAsync(user);
        }

        public async Task<int> AddUser(HealthCareUser user)
        {
              return await UnitOfWork.User.InsertAsync(user);
        }
        public async Task<HealthCareUser> IsUserExits(HealthCareUser user)
        {
            var obj = (await UnitOfWork.User.GetListAsync()).Where(x=> x.Username == user.Username).FirstOrDefault();
            return (obj != null) ? obj : null;
        }
        public async Task<HealthCareUser> GetUserById(int UserId)
        {
            var user = await UnitOfWork.User.GetByIdAsync(UserId);
            return user;
        }
        public async Task<UserViewModel> GetUserViewModelById(int UserId)
        {
            var obj = await UnitOfWork.User.GetByIdAsync(UserId);
            UserViewModel user = new UserViewModel{
                Username = obj.Username,
                ContactNumber = obj.ContactNumber,
                Age = (int)(DateTime.Now.Year - obj.DateOfBirth.Value.Year),
                Gender = (await UnitOfWork.Gender.GetByIdAsync(obj.GenderId??0)).GenderType
            };
            return user;
        }
        public async Task<List<UserViewModel>> GetUserViewModelList()
        {
            var userList = await UnitOfWork.User.GetListAsync();
            List<UserViewModel> users = new(); 
            foreach(var obj in userList)
            {
                users.Add(new UserViewModel
                {
                    Username = obj.Username,
                    ContactNumber = obj.ContactNumber,
                    Age = (int)(obj.DateOfBirth != null ? (DateTime.Now.Year - obj.DateOfBirth.Value.Year) : DateTime.Now.Year),
                    Gender = (await UnitOfWork.Gender.GetByIdAsync(obj.GenderId ?? 1)).GenderType
                });
            }
            return users;
        }
        public async Task<List<UserViewModel>> GetUsersBySearchText(string searchText)
        {
            return (await GetUserViewModelList()).Where(x => (x.Username != null && x.Username.ToLower().Contains(searchText.ToLower()))).ToList();
        }
        public async Task<HealthCareUser> GetUserByEmail(string Email)
        {
            var user = UnitOfWork.User.Find(x=> x.Email == Email).FirstOrDefault(); 
            return  user;
        }

    }
}
