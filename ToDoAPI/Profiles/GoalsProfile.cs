using AutoMapper;

namespace ToDoAPI.Profiles
{
    public class GoalsProfile : Profile
    {
        public GoalsProfile()
        {
            CreateMap<Models.Domain.Goal, Models.DTO.Goal>()
                .ReverseMap();
        }
    }
}
