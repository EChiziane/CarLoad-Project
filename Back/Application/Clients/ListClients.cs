using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Clients;

public class ListClients
{
    public class ListClientsQuery : IRequest<List<Client>>
    {
    }

    public class ListClientQueryHandler : IRequestHandler<ListClientsQuery, List<Client>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListClientQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Client>> Handle(ListClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _unitOfWork.Repository<Client>().ListAllAsync();
            return clients;
        }
    }
}