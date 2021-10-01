using AutoMapper;
using TryFi.Hotspot.Application.Queries.Models;
using TryFi.Hotspot.Domain.Entities;

namespace TryFi.Hotspot.Application.Queries.Profiles
{
    public  class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<Plan, PlanModel>();
        }
    }
}
