using Application.Interfaces;
using Application.Specifications.Carloads;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class ListCarload
{
    public class ListCarloadQuery : IRequest<List<CarLoadDto>>
    {
    }

    public class ListCarloadQueryHandler : IRequestHandler<ListCarloadQuery, List<CarLoadDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListCarloadQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CarLoadDto>> Handle(ListCarloadQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetCarLoadsSpecification();
            var carloads = await _unitOfWork.Repository<CarLoad>().ListWithSpecAsync(spec);
            return _mapper.Map<List<CarLoad>, List<CarLoadDto>>(carloads);
        }
    }
}