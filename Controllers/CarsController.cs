using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;
        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] CarSearchViewModel searchModel)
        {
            PopulateSearchOptions(searchModel);

            var cars = await _carsService.GetCarsAsync(searchModel.Year ?? 2000);

            var filteredResults = cars.AsEnumerable();

            if (!string.IsNullOrEmpty(searchModel.Make))
            {
                filteredResults = filteredResults.Where(c =>
                    c.Make.Equals(searchModel.Make, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchModel.Model))
            {
                filteredResults = filteredResults.Where(c =>
                    c.Model.Contains(searchModel.Model, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchModel.Engine))
            {
                filteredResults = filteredResults.Where(c =>
                    c.Fuel_Type.Equals(searchModel.Engine, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchModel.Transmission))
            {
                filteredResults = filteredResults.Where(c =>
                    c.Transmission.Equals(searchModel.Transmission, StringComparison.OrdinalIgnoreCase));
            }

            searchModel.Results = filteredResults.ToList();
            return View(searchModel);
        }

        [HttpGet]
        public async Task<IActionResult> TopTen()
        {
            var topCars = await _carsService.GetCarsAsync(2000);
            return View(topCars);
        }
        private void PopulateSearchOptions(CarSearchViewModel model)
        {
            model.CategoryOptions.Add(new SelectListItem { Value = "", Text = "All categories" });
            model.CategoryOptions.Add(new SelectListItem { Value = "cars", Text = "Cars and SUVs" });

            model.MakeOptions.Add(new SelectListItem { Value = "", Text = "All" });
            model.MakeOptions.Add(new SelectListItem { Value = "bmw", Text = "BMW" });
            model.MakeOptions.Add(new SelectListItem { Value = "audi", Text = "Audi" });
            model.MakeOptions.Add(new SelectListItem { Value = "mercedes-benz", Text = "Mercedes-benz" });
            model.MakeOptions.Add(new SelectListItem { Value = "nissan", Text = "Nissan" });
            model.MakeOptions.Add(new SelectListItem { Value = "lexus", Text = "Lexus" });
            model.MakeOptions.Add(new SelectListItem { Value = "kia", Text = "Kia" });


            model.YearOptions.Add(new SelectListItem { Value = "", Text = "All" });
            model.YearOptions.Add(new SelectListItem { Value = "2000", Text = "2000" });
            model.YearOptions.Add(new SelectListItem { Value = "2001", Text = "2001" });
            model.YearOptions.Add(new SelectListItem { Value = "2002", Text = "2002" });

            model.SortByOptions.Add(new SelectListItem { Value = "default", Text = "Make/Model/Price" });
            model.SortByOptions.Add(new SelectListItem { Value = "price_asc", Text = "Price (ascending)" });
            model.SortByOptions.Add(new SelectListItem { Value = "price_desc", Text = "Price (descending)" });

            model.EngineOptions.Add(new SelectListItem { Value = "", Text = "All" });
            model.EngineOptions.Add(new SelectListItem { Value = "gasoline", Text = "Gasoline" });
            model.EngineOptions.Add(new SelectListItem { Value = "diesel", Text = "Diesel" });
            model.EngineOptions.Add(new SelectListItem { Value = "electric", Text = "Electric" });

            model.TransmissionOptions.Add(new SelectListItem { Value = "", Text = "All" });
            model.TransmissionOptions.Add(new SelectListItem { Value = "manual", Text = "Manual" });
            model.TransmissionOptions.Add(new SelectListItem { Value = "automatic", Text = "Automatic" });
        }
    }
}
