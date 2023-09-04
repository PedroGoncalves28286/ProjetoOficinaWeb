using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Controllers
{
    public class AppointmentsController : Controller
    {

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IUserHelper _userHelper;

        public AppointmentsController(IAppointmentRepository appointmentRepository,
            IUserHelper userHelper)
        {

            _appointmentRepository = appointmentRepository;
            _userHelper = userHelper;
        }

        // GET: Appointments
        public IActionResult Index()
        {
            return View(_appointmentRepository.GetAll().OrderBy(p => p.Id));
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("AppointmentNotFound");
            }

            var appointment = await _appointmentRepository.GetByIdAsync(id.Value);

            if (appointment == null)
            {
                return new NotFoundViewResult("AppointmentNotFound");
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppointmentId,Date,Subject")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                //TODO :Modificar para o user que estiver logado 
                appointment.User = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
                await _appointmentRepository.CreateAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentRepository.GetByIdAsync(id.Value);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppointmentId,Date,Subject")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                    await _appointmentRepository.UpdateAsync(appointment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _appointmentRepository.ExistAsync(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("AppointmentNotFound");
            }

            var appointment = await _appointmentRepository.GetByIdAsync(id.Value);
            if (appointment == null)
            {
                return new NotFoundViewResult("AppointmentNotFound");
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            await _appointmentRepository.DeleteAsync(appointment);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AppointmentsNotFound()
        {
            return View();
        }



    }
}
