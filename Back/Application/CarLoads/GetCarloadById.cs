using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class GetCarloadById
{
    public class GetCarLoadByIdQuery : IRequest<CarLoadDto>
    {
        public int CarLoadId { get; set; }
    }

    public class GetCarLoadIdQueryHandler : IRequestHandler<GetCarLoadByIdQuery, CarLoadDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetCarLoadIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CarLoadDto> Handle(GetCarLoadByIdQuery request, CancellationToken cancellationToken)
        {
            var carload = await _unitOfWork.Repository<CarLoad>().GetByIdAsync(request.CarLoadId);

            if (carload is null)
                throw new Exception("No car load found");
            return _mapper.Map<CarLoad, CarLoadDto>(carload);
            ;
        }
    }
}