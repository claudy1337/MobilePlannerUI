using Microsoft.AspNetCore.Mvc;
using MobilePlanner.Application.Interfaces;
using MobilePlanner.Domain;
using MobilePlanner.Persistence;

namespace MobilePlanner.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlannerController : ControllerBase
    {
        //private readonly PlannerRepository _plannerRepository;
        public PlannerController(IPlannerRepository plannerRepository) => _plannerRepository = plannerRepository; 
        
        private readonly IPlannerRepository _plannerRepository;

        [HttpGet]
        public ActionResult<IEnumerable<Planner>> GetAllPlanners()
        {
            var plannerItems = _plannerRepository.GetAllPlanners();

            return Ok(plannerItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Planner> GetPlannerById([FromBody] int id)
        {
            var plan = _plannerRepository.GetPlannerById(id);

            return Ok(plan);
        }
    }
}
