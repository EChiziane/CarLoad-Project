using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class GetCarLoadToday
{
    public class GetCarLoadTodayQuery:IRequest<List<CarLoadDto>>
    {
        
    }
    
    public class GetCarLoadTodayHandler:IRequestHandler<GetCarLoadTodayQuery,List<CarLoadDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCarLoadTodayHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CarLoadDto>> Handle(GetCarLoadTodayQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetCarLoadTodaySpecification();
            var carloads = await _unitOfWork.Repository<CarLoad>().ListWithSpecAsync(spec);
            Console.Write(DateTime.Now.ToString("yyyy-M-d")+(" Now"));
            return _mapper.Map<List<CarLoad>, List<CarLoadDto>>(carloads);
        }
    }
}