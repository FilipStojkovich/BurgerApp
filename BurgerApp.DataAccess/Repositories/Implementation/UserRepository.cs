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
    public class UserRepository : IRepository<User>
    {
        private BurgerAppDbContext _dbContext;

        public UserRepository(BurgerAppDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public async Task<int> DeleteById(int id)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            _dbContext.Users.Remove(user);

            if (user == null)
            {
                throw new Exception($"User with Id:{id} was not found!");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Insert(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
