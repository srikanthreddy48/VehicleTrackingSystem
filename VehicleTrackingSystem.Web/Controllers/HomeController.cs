using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VehicleTrackingSystem.Web.Models;
using VehicleTrackingSystem.Web.ViewModels;

namespace VehicleTrackingSystem.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public  IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Vehicles()
        {
            var client = new HttpClient();
            //var token = await HttpContext.GetTokenAsync("access_token");
            //client.SetBearerToken(token);

            var response = await GetWithHandlingAsync(client, "https://localhost:44318/api/vehicle");
            //VehiclesViewModel vehiclesViewModel = new VehiclesViewModel();
            ViewBag.Json = JArray.Parse(await response.Content.ReadAsStringAsync()).ToString();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        private static async Task<HttpResponseMessage> GetWithHandlingAsync(HttpClient client, string apiRoute)
        {
            var response = await client.GetAsync(apiRoute);
            if (!response.IsSuccessStatusCode)
            {
                string error = "";
                string id = "";

                if (response.Content.Headers.ContentLength > 0)
                {
                    var j = JObject.Parse(await response.Content.ReadAsStringAsync());
                    error = (string)j["error"];
                    id = (string)j["id"];
                }
                //below logs warning with these details and THEN throws excpetion, which will also get logged
                //    but without the details from the API call and response.
                //    An alternative would be to use Serilog.Enrichers.Exceptions and include the API details
                //    in the ex.Data fields -- e.g. ex.Data.Add("ApiStatus", (int) response.StatusCode);
                //    Then you would throw the exception and only get ONE log entry with all of the details
                var ex = new Exception("API Failure");

                ex.Data.Add("API Route", $"GET {apiRoute}");
                ex.Data.Add("API Status", (int)response.StatusCode);
                if (!string.IsNullOrEmpty(error))
                {
                    ex.Data.Add("API Error", error);
                    ex.Data.Add("API ErrorId", id);
                }
                //Log.Warning(ex,
                //    "Got non-success response from API {ApiStatus}--{ApiError}--{ApiErrorId}--{ApiUrl}",
                //    (int) response.StatusCode,
                //    error,
                //    id,
                //    $"GET {apiRoute}");

                throw ex;
            }

            return response;
        }
    }
}
