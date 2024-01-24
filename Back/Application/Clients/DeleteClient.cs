using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Clients;

public class DeleteClient
{
    public class DeleteClientCommand : IRequest<Client>
    {
        public int ClientId { get; set; }
    }

    public class DeleteCostumerCommandHandler : IRequestHandler<DeleteClientCommand, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCostumerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(request.ClientId);
            if (client is null)
                throw new Exception("No Client Found");
            _unitOfWork.Repository<Client>().Delete(client);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return client;

            throw new Exception("Problem Deleting");
        }
    }
}