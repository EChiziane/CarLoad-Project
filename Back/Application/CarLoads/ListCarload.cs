using Application.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListCarloadQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CarLoadDto>> Handle(ListCarloadQuery request, CancellationToken cancellationToken)
        {
            var carloads = await _unitOfWork.Repository<CarLoad>().ListAllAsync();
            return _mapper.Map<List<CarLoad>,List<CarLoadDto>>(carloads);
        }
    }
}