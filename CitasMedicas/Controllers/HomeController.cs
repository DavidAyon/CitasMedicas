using CitasMedicas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CitasMedicas.Controllers
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
            return View("Login");
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

        [HttpGet]
        public IActionResult Redireccion(string clave, string userId)
        {
            var usuario = new Usuario
            {
                UserName = clave,
                Name = userId,
                Pws = userId
            };
            HttpContext.Session.SetString("Session", JsonSerializer.Serialize(usuario));
            return Json(new { status = true });
        }

        [HttpGet]
        public IActionResult CerrarSesion ()
        {
            var usuario = new Usuario
            {
                UserName = null,
                Name = null,
                Pws = null
            };
            HttpContext.Session.SetString("Session", JsonSerializer.Serialize(usuario));
            return Json(new { status = true });
        }
    }
}