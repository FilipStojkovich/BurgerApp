using BurgerApp.DataAccess.Repositories.Implementation;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Mappers;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.OrderViewModel;
using BurgerApp.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> _userRepository)
        {
            this._userRepository = _userRepository;
        }


        public async Task CreateUser(UserViewModel userViewModel)
        {
            await _userRepository.Insert(userViewModel.ToUser());
        }

        public async Task<int> DeleteUserById(int id)
        {
            return await _userRepository.DeleteById(id);
        }

        public async Task EditUser(UserViewModel userViewModel)
        {
            User userDb = await _userRepository.GetById(userViewModel.Id);

            if (userDb == null)
            {
                throw new Exception("User not found!");
            }

            userDb.FirstName = userViewModel.FirstName;
            userDb.LastName = userViewModel.LastName;
            userDb.Address = userViewModel.Address;

            await _userRepository.Update(userDb);
        }

        public async Task<UserDetailsViewModel> GetUserDetails(int id)
        {
            User userDb = await _userRepository.GetById(id);

            return userDb.ToUserDetailsViewModel();
        }

        public async Task<UserViewModel> GetUserForEditing(int id)
        {
            User user = await _userRepository.GetById(id);

            if (user == null)
            {
                throw new Exception("User not found"); 
            }

            UserViewModel userViewModel = user.ToUserViewModel();

            return userViewModel;
        }

        public async Task<List<UserListViewModel>> GetUsersForCards()
        {
            List<User> usersDb = await _userRepository.GetAll();

            return usersDb.Select(x => x.ToUserListViewModel()).ToList();
        }
    }
}
