using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models
{
    public class CarSearchViewModel
    {
        public string? Category { get; set; } 
        public string? Make { get; set; } 
        public string? Model { get; set; } 
        public int? MaxPrice { get; set; }
        public int? Year { get; set; }
        public string? SortBy { get; set; } 
        public string? Engine { get; set; } 
        public string? Transmission { get; set; } 

        public List<SelectListItem> CategoryOptions { get; set; } = new();
        public List<SelectListItem> MakeOptions { get; set; } = new();
        public List<SelectListItem> YearOptions { get; set; } = new();
        public List<SelectListItem> SortByOptions { get; set; } = new();
        public List<SelectListItem> EngineOptions { get; set; } = new();
        public List<SelectListItem> TransmissionOptions { get; set; } = new();

        public List<Car> Results { get; set; } = new();
    }
}
