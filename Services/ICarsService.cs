using WebApplication2.Controllers;

namespace WebApplication2.Services
{
    public interface ICarsService
    {
        Task<string> GetCarAsync(string make);
        Task<List<CarsController>> GetCarsAsync(string make);
    }
}
