using Auto.Services;
using CarsInfoDB.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Auto.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileService Carsservice)
        {
            _logger = logger;
            CarsService = Carsservice;
        }

        public JsonFileService CarsService { get; }
        public IEnumerable<Cars>? cars { get; private set; }

        public void OnGet() => cars = CarsService.GetCars();
    }
}