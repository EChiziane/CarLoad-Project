using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Materials;

public class DeleteMaterial
{
    public class DeleteMaterialCommand : IRequest<Material>
    {
        public int MaterialId { get; set; }
    }

    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand, Material>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Material> Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = await _unitOfWork.Repository<Material>().GetByIdAsync(request.MaterialId);
            if (material is null)
                throw new Exception("No Material Found");
            _unitOfWork.Repository<Material>().Delete(material);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return material;
            throw new Exception("Problem Deleting");
        }
    }
}