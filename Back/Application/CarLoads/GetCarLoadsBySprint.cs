using Application.Interfaces;
using Application.Specifications.Carloads;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class GetCarLoadsBySprint
{
    public class GetCarLoadsBySprintQuery : IRequest<List<CarLoadDto>>
    {
        public int SprintId { get; set; }
    }

    public class GetCarLoadsByQueryHandler : IRequestHandler<GetCarLoadsBySprintQuery, List<CarLoadDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCarLoadsByQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CarLoadDto>> Handle(GetCarLoadsBySprintQuery request,
            CancellationToken cancellationToken)
        {
            var spec = new GetCarloadBySprintSpecification(request.SprintId);
            var carloads = await _unitOfWork.Repository<CarLoad>().ListWithSpecAsync(spec);

            if (carloads is null)
                throw new Exception("No car load found");
            return _mapper.Map<List<CarLoad>, List<CarLoadDto>>(carloads);
        }
    }
}