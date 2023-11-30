using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ok.Models;
using System.Diagnostics;

namespace ok.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private Model Model = new Model();

        public IActionResult Index()
        {
            Aziende aziende = new Aziende();
            aziende.nomeazienda = "a";
            aziende.verifica = true;
            Model.aziende.Add(aziende);
            Model.SaveChanges();
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
    }
}