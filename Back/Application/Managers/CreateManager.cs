using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Managers;

public class CreateManager
{
    public class CreateManagerCommand : IRequest<Manager>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class CreateManagerCommandValidator : AbstractValidator<CreateManagerCommand>
    {
        public CreateManagerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Email).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
        }
    }

    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, Manager>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateManagerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Manager> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = new Manager
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };
            _unitOfWork.Repository<Manager>().Add(manager);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return manager;
            throw new Exception("Problem Saving");
        }
    }
}