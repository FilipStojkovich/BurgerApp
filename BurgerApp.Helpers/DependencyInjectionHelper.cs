using BurgerApp.DataAccess.DataContext;
using BurgerApp.DataAccess.Repositories.Implementation;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BurgerApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<BurgerAppDbContext>(options => options.UseSqlServer(@"Data Source=(localdb)\localdb;Database=BurgerAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False"));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Burger>, BurgerRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IBurgerService, BurgerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
