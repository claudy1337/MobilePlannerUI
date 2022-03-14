using MobilePlanner.Domain;

namespace MobilePlanner.Application.Interfaces
{
    public interface IPlannerRepository
    {
        IEnumerable<Planner> GetAllPlanners();
        Planner GetPlannerById(int id); 
    }
}
