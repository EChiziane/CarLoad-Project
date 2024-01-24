using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Clients;

public class CreateClient
{
    public class CreateClientCommand : IRequest<Client>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
        }
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateClientCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            };
            _unitOfWork.Repository<Client>().Add(client);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return client;
            throw new Exception("Problem Saving");
        }
    }
}