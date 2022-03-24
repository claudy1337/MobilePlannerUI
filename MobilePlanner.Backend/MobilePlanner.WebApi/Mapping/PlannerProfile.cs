using AutoMapper;
using MobilePlanner.Domain;
using MobilePlanner.WebApi.Dtos;

namespace MobilePlanner.WebApi.Mapping
{
    public class PlannerProfile : Profile
    {
        public PlannerProfile()
        {
            CreateMap<Planner, PlannerReadDto>().ReverseMap();
            CreateMap<PlannerCreateDto, Planner>().ReverseMap();
        }

    }
}
