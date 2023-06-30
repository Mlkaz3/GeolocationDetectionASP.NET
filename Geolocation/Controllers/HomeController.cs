using Geolocation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Geolocation.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {

            //var userIpAddress = httpContext.Connection.RemoteIpAddress.ToString();
            //ViewData["userIpAddress"] = userIpAddress;
            //var locationInfo = geolocationService.GetGeoInfoWithIP(userIpAddress);
            //ViewData["locationInfo"] = locationInfo.Result;

            return View();
        }

        public async Task<IActionResult> Geolocation() {

            var httpContext = _httpContextAccessor.HttpContext;
            var userIpAddress1 = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault() ?? httpContext.Connection.RemoteIpAddress.ToString();
            ViewData["userIpAddress1"] = userIpAddress1;
            var geolocationService = new GeoHelper();
            var ip = geolocationService.GetIPAddress();
            ViewData["ip"] = ip.Result;
            var locationInfo1 = geolocationService.GetGeoInfoWithIP(userIpAddress1).Result;
            ViewData["locationInfo1"] = locationInfo1; //this is the json string 
            var model = new GeolocationItem();
            model = JsonSerializer.Deserialize<GeolocationItem>(locationInfo1);


            //GeoHelper geoHelper = new GeoHelper();
            //var result = await geoHelper.GetGeoInfo();
            //ViewData["GeoCode"] = result; // i got this shit then i wanna deserialize it 

            //var model = new GeolocationItem();
            //model = JsonSerializer.Deserialize<GeolocationItem>(result);
            //ViewData["GeolocationItem"] = model;


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