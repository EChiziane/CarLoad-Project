using Application.Interfaces;
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
        public int ClientId { get; set; }
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
            RuleFor(x => x.ClientId).NotEmpty().NotNull();
            RuleFor(x => x.MaterialId).NotEmpty().NotNull();
            RuleFor(x => x.Toll).NotEmpty().NotNull();
            RuleFor(x => x.PurchaseMoney).NotEmpty().NotNull();
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
                ClientId = request.ClientId,
                Earnings = request.Earnings,
                ManagerExpenses = 150,
                DriverExpenses = 300,
                Expenses = request.PurchaseMoney
                           + request.FuelExpense
                           + request.Toll
                           + request.PoliceExpense
            };
            carload.Expenses += (carload.ManagerExpenses + carload.DriverExpenses);
            _unitOfWork.Repository<CarLoad>().Add(carload);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return carload;
            throw new Exception("Problem Saving");
        }
    }
}