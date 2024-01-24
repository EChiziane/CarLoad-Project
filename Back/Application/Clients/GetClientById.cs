using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Clients;

public class GetClientById
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int ClientId { get; set; }
    }

    public class GetClientByIdCommandHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(request.ClientId);
            if (client is null)
                throw new Exception("No Client Found");
            _unitOfWork.Repository<Client>().GetByIdAsync(request.ClientId);

            var result = await _unitOfWork.Complete() > 0;
            if (result) return client;

            throw new Exception("Problem Finding");
        }
    }
}