using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Drivers;

public class GetDriverById
{
    public class GetDriverByIdQuery : IRequest<Driver>
    {
        public int DriverId { get; set; }
    }

    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, Driver>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetDriverByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Driver> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Repository<Driver>().GetByIdAsync(request.DriverId);

            if (driver is null)
                throw new Exception("No Driver With This Id");
            return driver;
        }
    }
}