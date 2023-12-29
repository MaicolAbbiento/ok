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

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            Login? login = Model.Login.FirstOrDefault((e) => e.Username == model.Username && e.Password == model.Password);

            if (login != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("appuntamenti");
            }
            else
            {
                ViewBag.err = "Username o password errati";
            }
            return View();
        }

        public IActionResult regist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult regist(Login model)
        {
            if (model.Password == model.ConfermaPassword)
            {
                Login? l = Model.Login.FirstOrDefault((e) => e.Username == model.Username);
                if (l != null)
                {
                    Model.Login.Add(model);
                    Model.SaveChanges();
                    return RedirectToAction("login");
                }
                else
                {
                    ViewBag.utenteRegistrato = "utente gia registrato";
                    return View();
                }
            }
            else
            {
                ViewBag.err = "le password non coinscidono";
                return View();
            }
        }

        [Authorize]
        public IActionResult appuntamenti()
        {
            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult appuntamenti(Appunti model)
        {
            if (model.data > DateTime.Now && model.titolo != null && model.descrizione != null)
            {
                string i = User.Identity.Name;
                Login login = Model.Login.FirstOrDefault((e) => e.Username == i);
                model.idUtente = login.idUtente;
                Model.Appunti.Add(model);
                Model.SaveChanges();
                ViewBag.ap = "appuntamento aggiunto con successo";
            }
            return View();
        }

        [Authorize]
        public IActionResult home()
        {
            string i = User.Identity.Name;
            Login login = Model.Login.FirstOrDefault((e) => e.Username == i);
            List<Appunti> a = Model.Appunti.Where((e) => e.idUtente == login.idUtente && e.data > DateTime.Now

            ).ToList();
            return View(a);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}