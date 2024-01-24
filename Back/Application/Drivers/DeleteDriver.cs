using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Drivers;

public class DeleteDriver
{
    public class DeleteDriverCommand : IRequest<Driver>
    {
        public int DriverId { get; set; }
    }

    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, Driver>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDriverCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Driver> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.Repository<Driver>().GetByIdAsync(request.DriverId);
            if (guest is null)
                throw new Exception("No Driver Found");
            _unitOfWork.Repository<Driver>().Delete(guest);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return guest;

            throw new Exception("Problem Deleting");
        }
    }
}