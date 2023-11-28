using HealthCare.Data.Entity;
using HealthCare.ViewModels;
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
        Task<HealthCareUser> GetUserById(int UserId);
        Task<HealthCareUser> IsUserExits(HealthCareUser user);
        Task<UserViewModel> GetUserViewModelById(int UserId);
        Task<HealthCareUser> GetUserByEmail(string Email);
        Task UpdateUser(HealthCareUser user);
        Task<List<UserViewModel>> GetUserViewModelList();
        Task<List<UserViewModel>> GetUsersBySearchText(string searchText);
    }
}
