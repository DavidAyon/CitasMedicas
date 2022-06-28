using CitasMedicas.Business.Interfaces;
using CitasMedicas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CitasMedicas.Controllers
{
    public class CitaController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ICitaService _citaService;

        public CitaController(IDoctorService doctorService, ICitaService citaService)
        {
            _doctorService = doctorService;
            _citaService = citaService; 
        }
        // GET: CitaController
        public IActionResult CrearCita()
        {
            if (ValidateSession())
                return View(_doctorService.ConsultarDoctores());
            else
                return RedirectToAction("Index", "Home");
            //return View(_doctorService.ConsultarDoctores());
        }

        public IActionResult AgendaDoctor()
        {
            if (ValidateSession())
                return View(_doctorService.ConsultarDoctores());
            else
                return RedirectToAction("Index", "Home");
            //return View(_doctorService.ConsultarDoctores());
        }

        [HttpGet]
        public IActionResult ConsultarDoctores()
        {
            return Json(new { status = true, response = _doctorService.ConsultarDoctores(), msg = "Exito" });
        }

        [HttpPost]
        public IActionResult GuardarCita(Cita value)
        {
            return Json(new { status = _citaService.GuardarCita(value)});
        }

        [HttpGet]
        public IActionResult ConsultarAgendaDoctor(int doctorId, DateTime fecha)
        {
            return Json(new { status = true, response = _citaService.ConsultarAgenda(doctorId, fecha), msg = "Exito" });
        }

        [HttpGet]
        public IActionResult ConsultarCitas(int doctorId, DateTime fecha)
        {
            return Json(new { status = true, response = _citaService.ConsultarCitas(doctorId, fecha), msg = "Exito" });
        }

        private bool ValidateSession()
        {
            Usuario sesion = null;
            if (HttpContext.Session.GetString("Session") != null)
                sesion = JsonSerializer.Deserialize<Usuario>(HttpContext.Session.GetString("Session"));
            if (sesion != null)
                return true;
            else
                return false;
        }

    }
}
