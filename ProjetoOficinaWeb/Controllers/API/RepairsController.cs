using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoOficinaWeb.Data;

namespace ProjetoOficinaWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly IRepairRepository _repairRepository;

        public RepairsController(IRepairRepository repairRepository)
        {
            _repairRepository = repairRepository;
        }

        [HttpGet]
        public IActionResult GetRepairs()
        {
            return Ok( _repairRepository.GetAll());
        }
    }
}
