using CitasMedicas.Models;

namespace CitasMedicas.Business.Interfaces
{
    public interface ICitaService
    {
        bool GuardarCita(Cita cita);
        IEnumerable<Agenda> ConsultarAgenda(int doctorId, DateTime fecha);  
        IEnumerable<Cita> ConsultarCitas(int doctorId, DateTime fecha);
    }
}
