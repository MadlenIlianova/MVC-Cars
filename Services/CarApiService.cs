using Microsoft.Extensions.Options;
using System.Text.Json;
using WebApplication2.Controllers;
using WebApplication2.Models;


namespace WebApplication2.Services
{
    public class CarApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AppOptions _options;

        public CarApiService(HttpClient httpClient, AppOptions options)
        {
            _httpClient = httpClient;
            _options = options;
        }

        public async Task<List<Car>> GetCarsAsync(int year = 2000)
        {

            _httpClient.DefaultRequestHeaders.Clear();

            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _options.CarNinja);

            var makes = new[]
                {
                "lamborghini", "lexus", "land rover", "bmw", "hyundai",
                "nissan", "mazda", "mercedes", "chevrolet", "kia", "audi"
            };

            var allCars = new List<Car>();
            int imageIndex = 1;

            foreach (var make in makes)
            {
                string url = $"{_options.Url}?make={make}&year={year}";


                var response = await _httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();


                List<Car>? cars = null;

                cars = JsonSerializer.Deserialize<List<Car>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    AllowTrailingCommas = true
                });



                if (cars != null && cars.Count > 0)
                {
                    foreach (var car in cars)
                    {
                        car.ImageUrl = $"/images/car{imageIndex}.jpg";
                        imageIndex++;

                        if (imageIndex > 10) imageIndex = 1;
                    }

                    allCars.AddRange(cars);

                }
                if (allCars.Count >= 10)
                    break;
            }
            return allCars.Take(10).ToList();
        }      
    }
}


