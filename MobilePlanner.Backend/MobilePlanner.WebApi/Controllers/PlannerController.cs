using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobilePlanner.Application.Interfaces;
using MobilePlanner.Domain;
using MobilePlanner.Persistence;
using MobilePlanner.WebApi.Dtos;

namespace MobilePlanner.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlannerController : ControllerBase
    {
        public PlannerController(IPlannerRepository plannerRepository, IMapper mapper) => 
                (_plannerRepository, _mapper) = (plannerRepository, mapper); 
        
        private readonly IPlannerRepository _plannerRepository;
        private readonly IMapper _mapper;

        [HttpGet]
        public ActionResult<IEnumerable<PlannerReadDto>> GetAllPlanners()
        {
            var plannerItems = _plannerRepository.GetAllPlanners();

            return Ok(_mapper.Map<IEnumerable<PlannerReadDto>>(plannerItems));
        }

        [HttpGet("{id}", Name = "GetPlannerById")]
        public ActionResult<PlannerReadDto> GetPlannerById(int id)
        {
            var planner =  _plannerRepository.GetPlannerById(id);
            if (planner != null)
            {
                return Ok(_mapper.Map<PlannerReadDto>(planner)); 
            }
            return NotFound();
      
        }

        [HttpPost]
        public ActionResult<PlannerReadDto> CreatePlanner(PlannerCreateDto plannerCreateDto)
        {
            var plannerModel = _mapper.Map<Planner>(plannerCreateDto);
            _plannerRepository.CreatePlanner(plannerModel);
            _plannerRepository.SaveChanges();

            var plannerReadDto = _mapper.Map<PlannerReadDto>(plannerModel);
            return CreatedAtRoute(nameof(GetPlannerById), new { Id = plannerReadDto.Id}, plannerReadDto);

        } 
    }
}
