using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Managers;

public class ListManagers
{
    public class ListManagersQuery : IRequest<List<Manager>>
    {
    }

    public class ListManagerQueryHandler : IRequestHandler<ListManagersQuery, List<Manager>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListManagerQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Manager>> Handle(ListManagersQuery request, CancellationToken cancellationToken)
        {
            var managers = await _unitOfWork.Repository<Manager>().ListAllAsync();
            return managers;
        }
    }
}