using Microsoft.AspNetCore.Mvc;
using ProjetoOficinaWeb.Data;

namespace ProjetoOficinaWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public IActionResult GetAppointments()
        {
            return Ok(_appointmentRepository.GetAll());
        }
    }
}
