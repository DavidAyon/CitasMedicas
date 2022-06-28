using CitasMedicas.Business.Interfaces;
using CitasMedicas.Models;

namespace CitasMedicas.Business.Services
{
    public class CitaService : ICitaService
    {
        private readonly ApplicationDbContext _db;

        public CitaService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Agenda> ConsultarAgenda(int doctorId, DateTime fecha)
        {

            IEnumerable<Cita> citas = ConsultarCitas(doctorId, fecha);
            List<Agenda> agendaList = new List<Agenda>();
            if (citas != null)
            {
                for (int i = 10; i < 18; i++)
                {
                    Agenda agenda = new Agenda();
                    agenda.Hora = (i > 12 ? (i-12)+ " PM" : i +" AM");
                    var citaEncontrada = citas.FirstOrDefault(x => x.Hora == i);
                    if (citaEncontrada != null)
                    {
                        agenda.Correo = citaEncontrada.PacienteCorreo;
                        agenda.Paciente = citaEncontrada.PacienteNombre;
                    }
                    else
                    {
                        agenda.Correo = "No hay cita programada";
                        agenda.Paciente = "No hay cita programada";
                    }
                    agendaList.Add(agenda);
                }

            }
            return agendaList;
        }

        public bool GuardarCita(Cita cita)
        {
            _db.Citas.Add(cita);
            _db.SaveChanges();
            return true;
        }

        public IEnumerable<Cita> ConsultarCitas(int doctorId, DateTime fecha)
        {

            IEnumerable<Cita> citas = _db.Citas.Where(predicate: x => x.DoctorId == doctorId && x.Fecha == fecha).AsNoTracking();
            
            return citas;
        }
    }
}
