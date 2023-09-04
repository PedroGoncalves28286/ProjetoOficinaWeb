using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoOficinaWeb.Data;
using ProjetoOficinaWeb.Data.Entities;
using ProjetoOficinaWeb.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoOficinaWeb.Controllers
{
    public class MechanicsController : Controller
    {
        private readonly IMechanicRepository _mechanicRepository;
        private readonly IUserHelper _userHelper;

        public MechanicsController(IMechanicRepository mechanicRepository, 
            IUserHelper userHelper)
        {
            _mechanicRepository = mechanicRepository;
            _userHelper = userHelper;
        }

        // GET: Mechanics
        public IActionResult Index()
        {
            return View(_mechanicRepository.GetAll().OrderBy(p => p.Name));
        }

        // GET: Mechanics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("MechanicNotFound");
            }

            var mechanic = await _mechanicRepository.GetByIdAsync(id.Value);
            if (mechanic == null)


            {
                return new NotFoundViewResult("MechanicNotFound"); ;
            }

            return View(mechanic);
        }

        // GET: Mechanics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mechanics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specialization,Age,Photo")] Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                //TODO:Modificar para o user que estiver logado 
                mechanic.User = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
                await _mechanicRepository.CreateAsync(mechanic);
                return RedirectToAction(nameof(Index));
            }
            return View(mechanic);
        }

        // GET: Mechanics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("MechanicsNotFound");
            }

            var mechanic = await _mechanicRepository.GetByIdAsync(id.Value);
            if (mechanic == null)
            {
                return new NotFoundViewResult("MechanicsNotFound");
            }
            return View(mechanic);
        }

        // POST: Mechanics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialization,Age,Photo")] Mechanic mechanic)
        {
            if (id != mechanic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    await _mechanicRepository.UpdateAsync(mechanic);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _mechanicRepository.ExistAsync(mechanic.Id))
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
            return View(mechanic);
        }

        // GET: Mechanics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("MechanicNotFound");
            }

            var mechanic = await _mechanicRepository.GetByIdAsync(id.Value);
            if (mechanic == null)
            {
                return new NotFoundViewResult("MechanicNotFound");
            }

            return View(mechanic);
        }

        // POST: Mechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mechanic = await _mechanicRepository.GetByIdAsync(id);
            await _mechanicRepository.DeleteAsync(mechanic);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MechanicNotFound()
        {
            return View();
        }



    }
}
