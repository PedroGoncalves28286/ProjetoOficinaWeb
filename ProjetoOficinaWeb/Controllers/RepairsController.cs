using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data;
using ProjetoOficinaWeb.Data.Entities;

namespace ProjetoOficinaWeb.Controllers
{
    public class RepairsController : Controller
    {
        private readonly IRepairRepository _repairRepository;

        public RepairsController(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }

        // GET: Repairs
        public IActionResult Index()
        {
            return View(_repairRepository.GetAll());
        }

        // GET: Repairs/Details/5
        public  async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _repairRepository.GetByIdAsync(id.Value);
                
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // GET: Repairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vehicle,LicensePlate,Service,ServiceId,Appointment,AppointmentId,Mechanic")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                await _repairRepository.CreateAsync(repair);
                return RedirectToAction(nameof(Index));
            }
            return View(repair);
        }

        // GET: Repairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair =await _repairRepository.GetByIdAsync(id.Value);
            if (repair == null)
            {
                return NotFound();
            }
            return View(repair);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vehicle,LicensePlate,Service,ServiceId,Appointment,AppointmentId,Mechanic")] Repair repair)
        {
            if (id != repair.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repairRepository.UpdateAsync(repair);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _repairRepository.ExistAsync(repair.Id))
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
            return View(repair);
        }

        // GET: Repairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var repair = _repairRepository.GetByIdAsync(id.Value);

            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repair = await _repairRepository.GetByIdAsync(id);
           await _repairRepository.DeleteAsync(repair);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
