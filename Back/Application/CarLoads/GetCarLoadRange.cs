using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class GetCarLoadRange
{
    public class GetCarLoadRangeQuery:IRequest<List<CarLoadDto>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    
    public class GetCarLoadRangeHandler:IRequestHandler<GetCarLoadRangeQuery,List<CarLoadDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCarLoadRangeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CarLoadDto>> Handle(GetCarLoadRangeQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetCarLoadRangeSpecification(request.StartDate, request.EndDate);
            var carloads = await _unitOfWork.Repository<CarLoad>().ListWithSpecAsync(spec);
            return _mapper.Map<List<CarLoad>, List<CarLoadDto>>(carloads);
        }
    }
}