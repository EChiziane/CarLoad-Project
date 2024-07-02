using Application.Interfaces;
using Application.Specifications;
using Domain;
using MediatR;

namespace Application.Clients;

public class GetClientByNumberPhone
{
    public class GetClientByNumberPhoneQuery : IRequest<Client>
    {
        public string PhoneNumber { get; set; }
    }

    public class GetClientByNumberPhoneCommandHandler : IRequestHandler<GetClientByNumberPhoneQuery, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetClientByNumberPhoneCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(GetClientByNumberPhoneQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetClientByPhoneNumberSpecification(request.PhoneNumber);
            var client = await _unitOfWork.Repository<Client>().GetEntityWithSpec(spec);
            if (client is null)
                throw new Exception("No Client Found");
            return client;
        }
    }
}