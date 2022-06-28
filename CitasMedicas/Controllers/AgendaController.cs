using CitasMedicas.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CitasMedicas.Controllers
{
    public class AgendaController : Controller
    {
        
        public IActionResult AgendaDoctor()
        {
            return View();
        }

       
    }
}
