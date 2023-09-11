using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;

namespace ProjetoOficinaWeb.Controllers
{
    public class RepairsController : Controller
    {
        private readonly IRepairRepository _repairRepository;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobhelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;

        public RepairsController(IRepairRepository repairRepository,
            IUserHelper userHelper, IBlobHelper Blobhelper, IConverterHelper converterHelper)
        {
            _repairRepository = repairRepository;
            _userHelper = userHelper;
            _blobhelper = Blobhelper;
            _converterHelper = converterHelper;
        }

        // GET: Repairs
        public IActionResult Index()
        {
            return View(_repairRepository.GetAll().OrderBy(p => p.Id));
        }

        // GET: Repairs/Details/5
        public  async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("RepairNotFound");
            }

            var repair = await _repairRepository.GetByIdAsync(id.Value);
                
            if (repair == null)
            {
                return new NotFoundViewResult("RepairNotFound");
            }

            return View(repair);
        }

        // GET: Repairs/Create

        [ Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            throw new Exception("Excepção de Teste");
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
                //TODO:Modificar para o user que estiver logado 
                repair.User = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
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
                return new NotFoundViewResult("RepairNotFound");
            }

            var repair =await _repairRepository.GetByIdAsync(id.Value);
            if (repair == null)
            {
                return new NotFoundViewResult("RepairNotFound");
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
                   
                    await _repairRepository.UpdateAsync(repair);
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
                return new NotFoundViewResult("RepairNotFound");
            }
            var repair = await _repairRepository.GetByIdAsync(id.Value);

            if (repair == null)
            {
                return new NotFoundViewResult("RepairNotFound");
            }

            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repair = await _repairRepository.GetByIdAsync(id);
            try
            {
                //throw new Exception("Excepção de Teste");
                await _repairRepository.DeleteAsync(repair);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Delete"))
                {
                    ViewBag.ErrorTitle = $"{repair.LicensePlate} provavelmente está a ser usado !!";
                    ViewBag.ErrorMessage = $"{repair.LicensePlate} não pode ser apagado visto haverem serviços que o usam.</br></br>" +
                    $"Experimente primeiro apagar todas as reparações que estão a usar," +
                    $"e torne novamente a apagá-lo";

                }

                return View("Error");
            }
            
        }

        public IActionResult RepairNotFound()
        {
            return View();
        }

    }
}
