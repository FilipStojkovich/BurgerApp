using BurgerApp.Domain.Models;
using BurgerApp.ViewModels.OrderViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderListViewModel ToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel()
            {
                Id = order.Id,
                Name = order.Name,
                Location = order.Location,
            };
        }

        public static OrderDetailsViewModel ToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel()
            {
                Id = order.Id,
                Name = order.Name,
                Address = order.Address,
                Location = order.Location,
                IsDelivered = order.IsDelivered
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                Name = order.Name,
                Location = order.Location,
                Address = order.Address,
                IsDelivered = order.IsDelivered
            };
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            return new Order()
            {
                Id = orderViewModel.Id,
                Name = orderViewModel.Name,
                Location = orderViewModel.Location,
                IsDelivered = orderViewModel.IsDelivered,
                Address = orderViewModel.Address
            };
        }
    }
}
