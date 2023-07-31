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
    public class OrderRepository : IRepository<Order>
    {
        private BurgerAppDbContext _dbContext;

        public OrderRepository(BurgerAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<int> DeleteById(int id)
        {
            Order orderDb = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            _dbContext.Orders.Remove(orderDb);

            if (orderDb == null)
            {
                throw new Exception($"Item with Id:{id} was not found!");
            }

            _dbContext.Orders.Remove(orderDb);
            await _dbContext.SaveChangesAsync();

            return orderDb.Id;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task Insert(Order entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Order entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
