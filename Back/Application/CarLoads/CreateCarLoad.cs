using Application.Interfaces;
using Application.Specifications;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.CarLoads;

public class CreateCarLoad
{
    public class CreateCarLoadCommand : IRequest<CarLoad>
    {
        public string Destination { get; set; }
        public decimal Earnings { get; set; }
        public decimal FuelExpense { get; set; }
        public decimal PoliceExpense { get; set; }
        public int DriverId { get; set; }
        public int ManagerId { get; set; }
        public string ClientName { get; set; }
        public string ClientNumber { get; set; }
        public int SprintId { get; set; }
        public int MaterialId { get; set; }
        public decimal Toll { get; set; }
        public int PurchaseMoney { get; set; }
    }

    public class CreateCarLoadCommandValidator : AbstractValidator<CreateCarLoadCommand>
    {
        public CreateCarLoadCommandValidator()
        {
            RuleFor(x => x.Destination).NotEmpty().NotNull();
            RuleFor(x => x.Earnings).NotEmpty().NotNull();
            RuleFor(x => x.FuelExpense).NotEmpty().NotNull();
            RuleFor(x => x.PoliceExpense).NotEmpty().NotNull();
            RuleFor(x => x.DriverId).NotEmpty().NotNull();
            RuleFor(x => x.ManagerId).NotEmpty().NotNull();
            RuleFor(x => x.ClientName).NotEmpty().NotNull();
            RuleFor(x => x.MaterialId).NotEmpty().NotNull();
            RuleFor(x => x.Toll).NotEmpty().NotNull();
            RuleFor(x => x.SprintId).NotEmpty().NotNull();
            RuleFor(x => x.PurchaseMoney).NotEmpty().NotNull();
            RuleFor(x => x.ClientNumber).NotEmpty().NotNull();
        }
    }

    public class CreateCarLoadCommandHandler : IRequestHandler<CreateCarLoadCommand, CarLoad>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarLoadCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarLoad> Handle(CreateCarLoadCommand request, CancellationToken cancellationToken)
        {
            var spec = new GetSprintByIdSpecification(request.SprintId);
            var sprint = await _unitOfWork.Repository<Sprint>().GetEntityWithSpec(spec);

            if (sprint is null)
                throw new Exception("No Sprint With This Id");
            if (sprint.CarLoads.Count >= 18)
                throw new Exception("The sprint is overload");


            var specClient = new GetClientByPhoneNumberSpecification(request.ClientNumber);
            var client = await _unitOfWork.Repository<Client>().GetEntityWithSpec(specClient);
            if (client is null)
            {
                var Client = new Client
                {
                    Name = request.ClientName,
                    PhoneNumber = request.ClientNumber
                };
                _unitOfWork.Repository<Client>().Add(Client);
            }


            var carload = new CarLoad
            {
                Destination = request.Destination,
                MaterialId = request.MaterialId,
                FuelExpense = request.FuelExpense,
                PoliceExpense = request.PoliceExpense,
                Toll = request.Toll,
                PurchaseMoney = request.PurchaseMoney,
                DriverId = request.DriverId,
                ManagerId = request.ManagerId,
                Client = request.ClientName,
                ClientNumber = request.ClientNumber,
                Earnings = request.Earnings,
                SprintId = request.SprintId,
                ManagerExpenses = 150,
                DriverExpenses = 300
            };


            _unitOfWork.Repository<CarLoad>().Add(carload);

            sprint.CarLoads.Add(carload);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return carload;
            throw new Exception("Problem Saving");
        }
    }
}