using Application.Dtos;
using Application.Interfaces;
using Application.Specifications;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Sprints;

public class GetSprintById
{
    public class GetSprintByIdQuery : IRequest<SprintDto>
    {
        public int SprintId { get; set; }
    }

    public class GetSprintByIdQueryHandler : IRequestHandler<GetSprintByIdQuery, SprintDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSprintByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SprintDto> Handle(GetSprintByIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetSprintByIdSpecification(request.SprintId);
            var sprint = await _unitOfWork.Repository<Sprint>().GetEntityWithSpec(spec);

            if (sprint is null)
                throw new Exception("No Sprint With This Id");
            return _mapper.Map<Sprint, SprintDto>(sprint);
        }
    }
}