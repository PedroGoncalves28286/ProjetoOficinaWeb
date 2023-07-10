using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IServiceRepository _serviceRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository, IVehicleRepository vehicleRepository, IServiceRepository serviceRepository)
        {
            _appointmentRepository = appointmentRepository;
            _vehicleRepository = vehicleRepository;
            _serviceRepository = serviceRepository;
        }

        // GET: Appointments 
        public async Task<IActionResult> Index()
        {
            //var model = await _appointmentRepository.GetAppointmentAsync(this.User.Identity.Name);
            var model = _appointmentRepository.GetAll();
            return View(model);
        }

        [Authorize(Roles = "Receptionist,Mechanic")]
        public async Task<IActionResult> Create()
        {
            var model = await _appointmentRepository.GetDetailTempsAsync(this.User.Identity.Name);
            return View(model);
        }

        public IActionResult AddVehicle()
        {
            var model = new AddItemViewModel
            {
                Vehicles = _vehicleRepository.GetComboVehicles(),
                Services = _serviceRepository.GetComboServices()
            };

            return View(model);
        }

        [Authorize(Roles = "Receptionist,Mechanic")]
        [HttpPost]
        public async Task<IActionResult> AddVehicle(AddItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _appointmentRepository.AddItemToAppointmentAsync(model, this.User.Identity.Name);
                return RedirectToAction("Create");
            }

            return View(model);
        }

        [Authorize(Roles = "Receptionist,Mechanic")]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _appointmentRepository.DeleteDetailTempAsync(id.Value);
            return RedirectToAction("Create");
        }

        [Authorize(Roles = "Receptionist,Mechanic")]
        public async Task<IActionResult> Increase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _appointmentRepository.ModifyAppointmentDetailTempQuantityAsync(id.Value, 1);
            return RedirectToAction("Create");
        }

        [Authorize(Roles = "Receptionist,Mechanic")]
        public async Task<IActionResult> Decrease(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _appointmentRepository.ModifyAppointmentDetailTempQuantityAsync(id.Value, -1);
            return RedirectToAction("Create");
        }

        [Authorize(Roles = "Receptionist,Mechanic")]
        public async Task<IActionResult> ConfirmOrder()
        {
            var response = await _appointmentRepository.ConfirmAppointmentAsync(this.User.Identity.Name);
            if (response)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Repair(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _appointmentRepository.GetAppointmentAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            var model = new RepairViewModel
            {
                Id = order.Id,
                //RepairDate = DateTime.Today
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Repair(RepairViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _appointmentRepository.RepairOrder(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Appointments/Delete/5 // 
        [Authorize(Roles = "Receptionist, Mechanic")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("Error404");
            }

            var appointment = await _appointmentRepository.GetByIdAsync(id.Value);
            if (appointment == null)
            {
                return new NotFoundViewResult("Error404");
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [Authorize(Roles = "Receptionist, Mechanic")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id); ;

            try
            {
                await _appointmentRepository.DeleteAsync(appointment);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException != null && ex.InnerException.Message.Contains("DELETE"))
                {
                    ViewBag.ErrorTitle = $"{appointment.AppointmentDate} is being used!!";
                    ViewBag.ErrorMessage = $"{appointment.AppointmentDate} it´s not possible to delete</br></br>";
                }

                return View("Error");
            }
        }
    }
}

