using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.BurgerViewModel;
using BurgerApp.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.App.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetUsersForCards());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _userService.GetUserDetails(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _userService.DeleteUserById(id));
        }

        public IActionResult Create()
        {
            UserViewModel userViewModel = new UserViewModel();

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel userViewModel)
        {
            await _userService.CreateUser(userViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            UserViewModel userViewModel = await _userService.GetUserForEditing(id);

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            await _userService.EditUser(userViewModel);

            return RedirectToAction("Index");
        }
    }
}
