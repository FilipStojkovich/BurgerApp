using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModel;
using BurgerApp.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;

        public BurgerService(IRepository<Burger> _burgerRepository)
        {
            this._burgerRepository = _burgerRepository;
        }

        public async Task CreateBurger(BurgerViewModel burgerViewModel)
        {
            await _burgerRepository.Insert(burgerViewModel.ToBurger());
        }

        public async Task<int> DeleteBurgerById(int id)
        {
            return await _burgerRepository.DeleteById(id);
        }

        public async Task EditBurger(BurgerViewModel burgerViewModel)
        {
            Burger burgerDb = await _burgerRepository.GetById(burgerViewModel.Id);

            if(burgerDb == null)
            {
                throw new Exception("Burger not found!");
            }

            burgerDb.Name = burgerViewModel.Name;
            burgerDb.Price = burgerViewModel.Price;
            burgerDb.IsOnPromotion = burgerViewModel.IsOnPromotion;
            burgerDb.ImageUrl = burgerViewModel.ImageUrl;

            await _burgerRepository.Update(burgerDb);
        }

        public async Task<BurgerDetailsViewModel> GetBurgerDetails(int id)
        {
            Burger burgerDb = await _burgerRepository.GetById(id);

            return burgerDb.ToBurgerDetailsViewModel();
        }

        public async Task<BurgerViewModel> GetBurgerForEditing(int id)
        {
            Burger burger = await _burgerRepository.GetById(id);

            if(burger == null)
            {
                throw new Exception("Burger not found");
            }

            BurgerViewModel burgerViewModel = burger.ToBurgerViewModel();

            return burgerViewModel;
        }

        public async Task<List<BurgerListViewModel>> GetBurgersForCards()
        {
            List<Burger> burgersDb = await _burgerRepository.GetAll();

            return burgersDb.Select(x => x.ToBurgerListViewModel()).ToList();
        }
    }
}
