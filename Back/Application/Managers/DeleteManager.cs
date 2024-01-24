using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Managers;

public class DeleteManager
{
    public class DeleteManagerCommand : IRequest<Manager>
    {
        public int ManagerId { get; set; }
    }

    public class DeleteManagerCommandHandler : IRequestHandler<DeleteManagerCommand, Manager>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteManagerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Manager> Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = await _unitOfWork.Repository<Manager>().GetByIdAsync(request.ManagerId);

            if (manager is null)
                throw new Exception("No Manager With This Id");

            _unitOfWork.Repository<Manager>().Delete(manager);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return manager;

            throw new Exception("Problem Deleting");
        }
    }
}