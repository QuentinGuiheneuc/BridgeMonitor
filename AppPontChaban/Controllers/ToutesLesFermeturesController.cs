using AppPontChaban.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppPontChaban.Controllers
{
    public class ToutesLesFermeturesController : Controller
    {
        private readonly ILogger<ToutesLesFermeturesController> _logger;

        public ToutesLesFermeturesController(ILogger<ToutesLesFermeturesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Pont = ApiPontChaban.FermeturesPasserANDAVeunir();
            return View(Pont);
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
