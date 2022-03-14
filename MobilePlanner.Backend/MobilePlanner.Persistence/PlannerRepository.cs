using MobilePlanner.Application.Interfaces;
using MobilePlanner.Domain;

namespace MobilePlanner.Persistence
{
    public class MockPlannerRepository : IPlannerRepository
    {
        public IEnumerable<Planner> GetAllPlanners()
        {
            var planners = new List<Planner>
            {
                new Planner{Id = 1, Details = "Aboba", CreationDate = DateTime.Now, Title = "Boba"},
                new Planner{Id = 2, Details = "hfgh", CreationDate = DateTime.Now, Title = "Brtyoba"}
            };

            return  planners;
        }

        public Planner GetPlannerById(int id)
        {
            return new Planner { Id = 3, Details = "awef", CreationDate = DateTime.Now, Title = "asdqwd" };
        }
    }
}
