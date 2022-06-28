using CitasMedicas.Business.Interfaces;
using CitasMedicas.Models;

namespace CitasMedicas.Business.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _db;

        public DoctorService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Doctor> ConsultarDoctores()
        {
            IEnumerable<Doctor> doctors = _db.Doctores.AsNoTracking();
            return doctors;
        }
    }
}
