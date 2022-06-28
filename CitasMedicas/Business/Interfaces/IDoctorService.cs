using CitasMedicas.Models;

namespace CitasMedicas.Business.Interfaces
{
    
    public interface IDoctorService
    {
        IEnumerable<Doctor> ConsultarDoctores();
    }
}
