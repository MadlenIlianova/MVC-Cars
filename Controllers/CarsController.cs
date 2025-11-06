using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService carsService;
        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetCars([FromQuery] string make)
        {
            var cars = await carsService.GetCarAsync(make);
            return Ok(cars);
        }
    }
}


    





