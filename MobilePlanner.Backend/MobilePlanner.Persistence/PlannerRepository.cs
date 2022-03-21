using MobilePlanner.Application.Interfaces;
using MobilePlanner.Domain;

namespace MobilePlanner.Persistence
{
    public class PlannerRepository : IPlannerRepository
    {
        private readonly PlannerDBContext _dbContext;
        public PlannerRepository(PlannerDBContext dBContext) => _dbContext = dBContext;
        public IEnumerable<Planner> GetAllPlanners()
        {
            return _dbContext.Planners.ToList();
        }

        public Planner GetPlannerById(int id)
        {
            return _dbContext.Planners.FirstOrDefault(planner => planner.Id == id);
        }
    }
}
