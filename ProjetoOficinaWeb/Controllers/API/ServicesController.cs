using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoOficinaWeb.Data;

namespace ProjetoOficinaWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IRepairRepository _repairRepository;

        public ServicesController(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            return Ok(_repairRepository.GetAllWithUsers());
        }
    }
}
