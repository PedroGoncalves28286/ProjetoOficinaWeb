using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using ProjetoOficinaWeb.Models;

namespace ProjetoOficinaWeb.Controllers
{
    [Authorize]
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;

        public VehiclesController(IVehicleRepository vehicleRepository,
           IUserHelper userHelper, IBlobHelper blobHelper,IConverterHelper converterHelper)
        {

            _vehicleRepository = vehicleRepository;
            _userHelper = userHelper;  
            _blobHelper = blobHelper;
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
              return new NotFoundViewResult("VehiclesNotFound");
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(id.Value);

            if (vehicle == null)
            {
                return new NotFoundViewResult("VehiclesNotFound");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create

        [Authorize(Roles = "Admin")]
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
                Guid imageId = Guid.Empty;

                if(view.ImageFile != null && view.ImageFile.Length > 0)
                {

                    imageId = await _blobHelper.UploadBlobAsync(view.ImageFile,"vehicles");
                        
                }

                var vehicle = _converterHelper.ToVehicle(view, imageId, true);

                //TODO:Modificar para o user que estiver logado 
                vehicle.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await _vehicleRepository.CreateAsync(vehicle);
                return RedirectToAction(nameof(Index));        
            }
            return View(view);
        }



        // GET: Vehicles/Edit/5

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("VehiclesNotFound");
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(id.Value);
            if (vehicle == null)
            {
                return new NotFoundViewResult("VehiclesNotFound");
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
                    Guid imageId = view.ImageId;

                    if(view.ImageFile != null && view.ImageFile.Length > 0)
                    {

                          imageId = await _blobHelper.UploadBlobAsync(view.ImageFile, "vehicles"); 

                       
                    }
                    var vehicle = _converterHelper.ToVehicle(view, imageId, false);

                    // Todo:Modificar para o user que estiver logado 
                    vehicle.User = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
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

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("VehiclesNotFound");
            }

            var vehicle = await _vehicleRepository.GetByIdAsync(id.Value);
                
            if (vehicle == null)
            {
                return new NotFoundViewResult("VehiclesNotFound");
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
        
        public IActionResult VehicleNotFound()
        {
            return View();
        }

       
        
    }
}
