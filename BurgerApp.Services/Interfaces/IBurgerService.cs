using BurgerApp.ViewModels.BurgerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Interfaces
{
    public interface IBurgerService
    {
        Task<List<BurgerListViewModel>> GetBurgersForCards();
        Task<BurgerDetailsViewModel> GetBurgerDetails(int id);
        Task<int> DeleteBurgerById(int id);
        Task CreateBurger(BurgerViewModel burgerViewModel);
        Task<BurgerViewModel> GetBurgerForEditing(int id);
        Task EditBurger(BurgerViewModel burgerViewModel);
    }
}
