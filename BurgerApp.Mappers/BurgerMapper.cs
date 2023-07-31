using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.BurgerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers
{
    public static class BurgerMapper
    {
        public static BurgerListViewModel ToBurgerListViewModel(this Burger burger)
        {
            return new BurgerListViewModel()
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                ImageUrl = burger.ImageUrl
            };
        }

        public static BurgerDetailsViewModel ToBurgerDetailsViewModel(this Burger burger)
        {
            return new BurgerDetailsViewModel()
            {
                Id = burger.Id,
                Name = burger.Name,
                Price = burger.Price,
                IsOnPromotion = burger.IsOnPromotion,
                IsVegeterian = burger.IsVegeterian,
                IsVegan = burger.IsVegan,
                HasFries = burger.HasFries,
                ImageUrl = burger.ImageUrl
            };
        }

        public static BurgerViewModel ToBurgerViewModel(this Burger burgerDb)
        {
            return new BurgerViewModel()
            {
                Id = burgerDb.Id,
                Name = burgerDb.Name,
                Price = burgerDb.Price,
                IsOnPromotion = burgerDb.IsOnPromotion,
                ImageUrl = burgerDb.ImageUrl
            };
        }

        public static Burger ToBurger(this BurgerViewModel burgerViewModel)
        {
            return new Burger()
            {
                Name = burgerViewModel.Name,
                Price = burgerViewModel.Price,
                IsOnPromotion = burgerViewModel.IsOnPromotion,
                ImageUrl = burgerViewModel.ImageUrl
            };
        }
    }
}
