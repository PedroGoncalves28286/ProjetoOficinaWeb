using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoOficinaWeb.Data;

namespace ProjetoOficinaWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicsController : ControllerBase
    {
        private readonly IMechanicRepository _mechanicRepository; 
        
        public MechanicsController(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        [HttpGet]
        public IActionResult GetMechanics()
        {
            return Ok(_mechanicRepository.GetAllWithUsers());
        }
    }
}
