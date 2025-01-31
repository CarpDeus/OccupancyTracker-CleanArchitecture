using AutoMapper;
using MediatR;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.Application.DTOs.OccupanyLogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog
{
    public class CreateOccupancyLogCommandHandler : IRequestHandler<CreateOccupancyLogCommand, CreateOccupancyLogCommandResponse>
    {
        private readonly IOccupanyLogRepository _occupancyLogRepository;
        private readonly IMapper _mapper;
        
        public CreateOccupancyLogCommandHandler(IOccupanyLogRepository occupancyLogRepository, IMapper mapper)
        {
            _occupancyLogRepository = occupancyLogRepository;
            _mapper = mapper;
        }
        
        public async Task<CreateOccupancyLogCommandResponse> Handle(CreateOccupancyLogCommand request, CancellationToken cancellationToken)
        {
            var createOccupancyLogCommandResponse = new CreateOccupancyLogCommandResponse();
            var occupancyLog = _mapper.Map<OccupancyLogDto>(request);
            createOccupancyLogCommandResponse = await _occupancyLogRepository.AddAsync(occupancyLog);
            return createOccupancyLogCommandResponse;
        }
    }
}
