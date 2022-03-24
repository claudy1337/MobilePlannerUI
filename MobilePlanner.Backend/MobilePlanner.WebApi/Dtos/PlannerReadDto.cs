namespace MobilePlanner.WebApi.Dtos
{
    public class PlannerReadDto
    {
      
        public int Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
