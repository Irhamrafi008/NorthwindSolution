using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
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
            var myName = "Irham Rafi";
            return View("index", myName);
        }

        public IActionResult Privacy()
        {
            var hour = DateTime.Now.Hour;
            // ternary opetarion
            var greeting = hour > 12 ? "Good Day" : "Good Morning";
            return View("privacy",greeting);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
