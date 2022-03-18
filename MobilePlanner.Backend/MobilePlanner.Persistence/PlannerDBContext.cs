using Microsoft.EntityFrameworkCore;
using MobilePlanner.Domain;

namespace MobilePlanner.Persistence
{
    public class PlannerDBContext : DbContext
    {
        public PlannerDBContext(DbContextOptions<PlannerDBContext> opt) : base(opt)
        {

        }

        DbSet<Planner> Planners{ get; set; }
    }
}
