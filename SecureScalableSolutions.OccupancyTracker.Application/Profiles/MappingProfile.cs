using AutoMapper;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.UpdateOrganization;
using SecureScalableSolutions.OccupancyTracker.Domain.Entities;

namespace SecureScalableSolutions.OccupancyTracker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Organization, CreateOrganizationCommand>().ReverseMap();
            CreateMap<Organization, UpdateOrganizationCommand>().ReverseMap();

        }
    }
}
