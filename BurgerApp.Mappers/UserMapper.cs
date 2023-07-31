using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.UserViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers
{
    public static class UserMapper
    {
        public static UserListViewModel ToUserListViewModel(this User user)
        {
            return new UserListViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public static UserDetailsViewModel ToUserDetailsViewModel(this User user)
        {
            return new UserDetailsViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public static User ToUser(this UserViewModel userViewModel)
        {
            return new User()
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Address = userViewModel.Address
            };
        }
    }
}
