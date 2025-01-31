using AutoMapper;
using SecureScalableSolutions.OccupancyTracker.Application.DTOs.OccupanyLogDto;
using SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog;
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
            CreateMap<CreateOccupancyLogCommand, OccupancyLogDto>();
        }
    }
}
