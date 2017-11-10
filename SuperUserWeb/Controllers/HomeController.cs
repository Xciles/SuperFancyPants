using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SuperUserWeb.Models;
using SuperUserWeb.Utils;

namespace SuperUserWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IStringLocalizer<HomeController> localizer, ILogger<HomeController> logger)
        {

            _localizer = localizer;
            _logger = logger;

        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation(_localizer["Hello"]);

            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var requestCulture = requestCultureFeature.RequestCulture;
            var loc = _localizer.WithCulture(requestCulture.Culture);
            var hello = loc["Hello"];

            _logger.LogInformation(hello);

            //await SendGridMailer.SendMessage("xciles@gmail.com", "Hallo", "Hallo een test berichtje.");

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
