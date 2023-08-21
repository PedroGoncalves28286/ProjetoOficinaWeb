using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Data
{
    public class AppointmentRepository : GenericRepository<Appointment>,IAppointmentRepository
    {
        public AppointmentRepository(DataContext context) : base(context)
        {
            
        }
    }
}
