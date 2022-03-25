using MobilePlanner.Domain;

namespace MobilePlanner.Application.Interfaces
{
    public interface IPlannerRepository
    {
        void SaveChanges();
        IEnumerable<Planner> GetAllPlanners();
        Planner GetPlannerById(int id);
        void CreatePlanner(Planner planner);
        void UpdatePlanner(Planner plannerModelFromRepository);
        void DeletePlanner(Planner planner);
    }
}
