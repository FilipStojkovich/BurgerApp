using BurgerApp.DataAccess.Repositories.Implementation;
using BurgerApp.DataAccess.Repositories.Interfaces;
using BurgerApp.Domain.Models;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModel;
using BurgerApp.ViewModels.OrderViewModel;
using BurgerApp.Mappers;

namespace BurgerApp.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> _orderRepository)
        {
            this._orderRepository = _orderRepository;
        }

        public async Task CreateOrder(OrderViewModel orderViewModel)
        {
            await _orderRepository.Insert(orderViewModel.ToOrder());
        }

        public async Task<int> DeleteOrderById(int id)
        {
            return await _orderRepository.DeleteById(id);
        }

        public async Task EditOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = await _orderRepository.GetById(orderViewModel.Id);

            if (orderDb == null)
            {
                throw new Exception("Order not found!");
            }

            orderDb.Name = orderViewModel.Name;
            orderDb.Location = orderViewModel.Location;
            orderDb.IsDelivered = orderViewModel.IsDelivered;

            await _orderRepository.Update(orderDb);
        }

        public async Task<OrderDetailsViewModel> GetOrderDetails(int id)
        {
            Order orderDb = await _orderRepository.GetById(id);

            return orderDb.ToOrderDetailsViewModel();
        }

        public async Task<OrderViewModel> GetOrderForEditing(int id)
        {
            Order order = await _orderRepository.GetById(id);

            if (order == null)
            {
                throw new Exception("Order not found");
            }

            OrderViewModel orderViewModel = order.ToOrderViewModel();

            return orderViewModel;
        }

        public async Task<List<OrderListViewModel>> GetOrdersForCards()
        {
            List<Order> ordersDb = await _orderRepository.GetAll();

            return ordersDb.Select(x => x.ToOrderListViewModel()).ToList();
        }
    }
}
