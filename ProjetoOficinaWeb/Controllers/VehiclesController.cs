using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserHelper _userHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public VehiclesController(IVehicleRepository vehicleRepository,
           IUserHelper userHelper, IImageHelper imageHelper,IConverterHelper converterHelper)
        {

            _vehicleRepository = vehicleRepository;
            _userHelper = userHelper;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }    

        // GET: Vehicles
        public IActionResult Index()
        {
            return View(_vehicleRepository.GetAll().OrderBy(p => p.Id));
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if(view.ImageFile != null && view.ImageFile.Length > 0)
                {

                    path = await _imageHelper.UploadImageAsync(view.ImageFile,"vehicles");
                }

                var vehicle = _converterHelper.ToVehicle(view, path, true);

                //TODO:Modificar para o user que estiver logado 
                vehicle.User = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
                await _vehicleRepository.CreateAsync(vehicle);
                return RedirectToAction(nameof(Index));        
            }
            return View(view);
        }

        

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(id.Value);
            if (vehicle == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToVehicleViewModel(vehicle);
            return View(model);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VehicleViewModel view)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl; 

                    if(view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid =Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = await _imageHelper.UploadImageAsync(view.ImageFile, "vehicles");

                       
                    }
                    var vehicle = _converterHelper.ToVehicle(view, path, false);

                    // Todo:Modificar para o user que estiver logado 
                    vehicle.User = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
                    await _vehicleRepository.UpdateAsync(vehicle);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _vehicleRepository.ExistAsync(view.Id))
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
            return View(view);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(id.Value);
                
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            await _vehicleRepository.DeleteAsync(vehicle);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
