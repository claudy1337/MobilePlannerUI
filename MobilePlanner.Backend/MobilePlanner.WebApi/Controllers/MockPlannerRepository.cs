using Microsoft.AspNetCore.Mvc;
using MobilePlanner.Domain;
using MobilePlanner.Persistence;

namespace MobilePlanner.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MockPlannerRepository : ControllerBase
    {
        //private readonly PlannerRepository _plannerRepository;
        //public PlannersController(PlannerRepository plannerRepository) => _plannerRepository = plannerRepository; 
        private readonly Persistence.MockPlannerRepository _plannerRepository = new Persistence.MockPlannerRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Planner>> GetAllPlanners()
        {
            var plannerItems = _plannerRepository.GetAllPlanners();

            return Ok(plannerItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Planner> GetPlannerById(int id)
        {
            var plan = _plannerRepository.GetPlannerById(id);

            return Ok(plan);
        }
    }
}
