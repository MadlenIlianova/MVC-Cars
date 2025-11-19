using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
        public class HomeController : Controller
        {
        private readonly ICarsService _carService;

        public HomeController(ICarsService carService)
        {
            _carService = carService;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetCarsAsync(2000);
            return View(cars);
        }
    }
}
