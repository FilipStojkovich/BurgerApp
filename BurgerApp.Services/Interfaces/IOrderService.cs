using BurgerApp.ViewModels.BurgerViewModel;
using BurgerApp.ViewModels.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderListViewModel>> GetOrdersForCards();
        Task<OrderDetailsViewModel> GetOrderDetails(int id);
        Task<int> DeleteOrderById(int id);
        Task CreateOrder(OrderViewModel orderViewModel);
        Task<OrderViewModel> GetOrderForEditing(int id);
        Task EditOrder(OrderViewModel orderViewModel);
    }
}
