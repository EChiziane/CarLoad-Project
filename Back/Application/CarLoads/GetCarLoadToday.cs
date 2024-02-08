using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class GetCarLoadToday
{
    public class GetCarLoadTodayQuery : IRequest<List<CarLoadDto>>
    {
    }

    public class GetCarLoadTodayHandler : IRequestHandler<GetCarLoadTodayQuery, List<CarLoadDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCarLoadTodayHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CarLoadDto>> Handle(GetCarLoadTodayQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetCarLoadTodaySpecification();
            var carloads = await _unitOfWork.Repository<CarLoad>().ListWithSpecAsync(spec);
            return _mapper.Map<List<CarLoad>, List<CarLoadDto>>(carloads);
        }
    }
}