using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Sprints;

public class DeleteSprint
{
    public class DeleteSprintCommand : IRequest<Sprint>
    {
        public int SprintId { get; set; }
    }

    public class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, Sprint>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSprintCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Sprint> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
        {
            var sprint = await _unitOfWork.Repository<Sprint>().GetByIdAsync(request.SprintId);
            if (sprint is null)
                throw new Exception("No Sprint Found");

            _unitOfWork.Repository<Sprint>().Delete(sprint);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return sprint;

            throw new Exception("Problem Deleting");
        }
    }
}