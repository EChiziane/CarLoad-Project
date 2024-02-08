using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.CarLoads;

public class GetCarloadById
{
    public class GetCarLoadByIdQuery : IRequest<CarLoad>
    {
        public int CarLoadId { get; set; }
    }

    public class GetCarLoadIdQueryHandler : IRequestHandler<GetCarLoadByIdQuery, CarLoad>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarLoadIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarLoad> Handle(GetCarLoadByIdQuery request, CancellationToken cancellationToken)
        {
            var carload = await _unitOfWork.Repository<CarLoad>().GetByIdAsync(request.CarLoadId);

            if (carload is null)
                throw new Exception("No car load found");
            return carload;
        }
    }
}