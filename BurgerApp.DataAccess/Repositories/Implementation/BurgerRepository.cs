using BurgerApp.DataAccess.DataContext;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Repositories.Implementation
{
    public class BurgerRepository : IRepository<Burger>
    {
        private BurgerAppDbContext _dbContext;

        public BurgerRepository(BurgerAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<int> DeleteById(int id)
        {
            Burger burgerDb = await _dbContext.Burgers.FirstOrDefaultAsync(x => x.Id == id);

            _dbContext.Burgers.Remove(burgerDb);

            if(burgerDb == null)
            {
                throw new Exception($"Item with Id:{id} was not found!");
            }

            _dbContext.Burgers.Remove(burgerDb);
            await _dbContext.SaveChangesAsync();

            return burgerDb.Id;
        }

        public async Task<List<Burger>> GetAll()
        {
            return await _dbContext.Burgers.ToListAsync();
        }

        public async Task<Burger> GetById(int id)
        {
            return await _dbContext.Burgers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(Burger entity)
        {
            await _dbContext.Burgers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Burger entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
