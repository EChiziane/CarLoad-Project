using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Managers;

public class GetManagerById
{
    public class GetManagerByIdQuery : IRequest<Manager>
    {
        public int ManagerId { get; set; }
    }

    public class GetManagerByIdQueryHandler : IRequestHandler<GetManagerByIdQuery, Manager>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetManagerByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Manager> Handle(GetManagerByIdQuery request, CancellationToken cancellationToken)
        {
            var manager = await _unitOfWork.Repository<Manager>().GetByIdAsync(request.ManagerId);

            if (manager is null)
                throw new Exception("No Manager With This Id");

            return manager;
        }
    }
}