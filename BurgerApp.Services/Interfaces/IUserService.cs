using BurgerApp.ViewModels.OrderViewModel;
using BurgerApp.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserListViewModel>> GetUsersForCards();
        Task<UserDetailsViewModel> GetUserDetails(int id);
        Task<int> DeleteUserById(int id);
        Task CreateUser(UserViewModel userViewModel);
        Task<UserViewModel> GetUserForEditing(int id);
        Task EditUser(UserViewModel userViewModel);
    }
}
