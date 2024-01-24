using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Drivers;

public class CreateDriver
{
    public class CreateDriverCommand : IRequest<Driver>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string VehiclePlate { get; set; }
        public string VehicleModel { get; set; }
    }

    public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
    {
        public CreateDriverCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.BirthDate).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.VehicleModel).NotEmpty().NotNull();
            RuleFor(x => x.VehiclePlate).NotEmpty().NotNull();
        }
    }

    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Driver>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDriverCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Driver> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = new Driver
            {
                Name = request.Name,
                BirthDate = request.BirthDate,
                PhoneNumber = request.PhoneNumber,
                VehicleModel = request.VehicleModel,
                VehiclePlate = request.VehiclePlate
            };
            _unitOfWork.Repository<Driver>().Add(driver);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return driver;
            throw new Exception("Problem Saving");
        }
    }
}