using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModel;
using BurgerApp.ViewModels.OrderViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.App.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.GetOrdersForCards());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _orderService.GetOrderDetails(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _orderService.DeleteOrderById(id));
        }

        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel orderViewModel)
        {
            await _orderService.CreateOrder(orderViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            OrderViewModel orderViewModel = await _orderService.GetOrderForEditing(id);

            return View(orderViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderViewModel orderViewModel)
        {
            await _orderService.EditOrder(orderViewModel);

            return RedirectToAction("Index");
        }
    }
}
