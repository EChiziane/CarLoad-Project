using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Sprints;

public class CreateSprint
{
    public class CreateSprintCommand : IRequest<Sprint>
    {
        public string Name { get; set; }
        public int DriverId { get; set; }
    }

    public class CreateSprintCommandValidator : AbstractValidator<CreateSprintCommand>
    {
        public CreateSprintCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.DriverId).GreaterThan(0);
        }
    }

    public class CreateSprintCommandHandler : IRequestHandler<CreateSprintCommand, Sprint>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSprintCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Sprint> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.Repository<Driver>().GetByIdAsync(request.DriverId);
            if (driver == null) throw new Exception("Driver not found");

            var sprint = new Sprint
            {
                Name = request.Name,
                DriverId = request.DriverId,
                Driver = driver
            };

            _unitOfWork.Repository<Sprint>().Add(sprint);
            var result = await _unitOfWork.Complete() > 0;

            if (result) return sprint;

            throw new Exception("Problem Saving");
        }
    }
}