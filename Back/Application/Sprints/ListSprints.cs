using Application.Dtos;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Sprints;

public class ListSprints
{
    public class ListSprintsQuery : IRequest<List<SprintDto>>
    {
    }

    public class ListSprintsQueryHandler : IRequestHandler<ListSprintsQuery, List<SprintDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListSprintsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SprintDto>> Handle(ListSprintsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetSprintSpecification();
            var sprints = await _unitOfWork.Repository<Sprint>().ListWithSpecAsync(spec);
            return _mapper.Map<List<Sprint>, List<SprintDto>>(sprints);
        }
    }
}