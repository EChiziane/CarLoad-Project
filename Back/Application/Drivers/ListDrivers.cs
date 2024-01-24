using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Drivers;

public class ListDrivers
{
    public class ListDriversQuery : IRequest<List<Driver>>
    {
    }

    public class ListDriverQueryHandler : IRequestHandler<ListDriversQuery, List<Driver>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListDriverQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Driver>> Handle(ListDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.Repository<Driver>().ListAllAsync();
            return drivers;
        }
    }
}