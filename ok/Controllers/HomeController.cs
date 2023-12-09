using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ok.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Diagnostics;
using IdentityServer3.Core.ViewModels;
using ErrorViewModel = IdentityServer3.Core.ViewModels.ErrorViewModel;

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

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // Esegui il logout dell'utente
            await HttpContext.SignOutAsync();

            // Log dell'evento di logout

            // Reindirizza all'azione o alla pagina desiderata dopo il logout
            return RedirectToAction("Index", "Home"); // Puoi specificare una diversa destinazione dopo il logout
        }

        // Azione per la pagina di login
        [HttpGet]
        public IActionResult Login()
        {
            // Mostra la vista del form di login
            return View();
        }

        // Azione per il post del form di login
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Alcune proprietà aggiuntive, se necessario
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Reindirizza l'utente alla pagina successiva al login
                return RedirectToAction("Index");
            }

            // Se le credenziali non sono valide, mostra di nuovo il form di login con un messaggio di errore
            ModelState.AddModelError(string.Empty, "Credenziali non valide.");
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult pagina()
        {
            Model.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}