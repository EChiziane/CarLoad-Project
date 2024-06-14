using Application.Dtos;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Sprints;

public class GetSprints
{
    public class GetSprintsQuery : IRequest<List<SprintDto>>
    {
    }

    public class GetSprintsQueryHandler : IRequestHandler<GetSprintsQuery, List<SprintDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSprintsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SprintDto>> Handle(GetSprintsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetSprintSpecification();
            var sprints = await _unitOfWork.Repository<Sprint>().ListWithSpecAsync(spec);
            return _mapper.Map<List<Sprint>, List<SprintDto>>(sprints);
        }
    }
}