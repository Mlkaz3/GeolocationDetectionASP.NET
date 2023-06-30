using Geolocation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Geolocation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Geolocation() {
            GeoHelper geoHelper = new GeoHelper();
            var result = await geoHelper.GetGeoInfo();
            ViewData["GeoCode"] = result; // i got this shit then i wanna deserialize it 

            var model = new GeolocationItem();
            model = JsonSerializer.Deserialize<GeolocationItem>(result);
            ViewData["GeolocationItem"] = model;


            return View(model);  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}