using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Materials;

public class GetMaterialById
{
    public class GetMaterialByIdQuery : IRequest<Material>
    {
        public int MaterialId { get; set; }
    }

    public class GetMaterialByIdCommandHandler : IRequestHandler<GetMaterialByIdQuery, Material>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMaterialByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Material> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken)
        {
            var material = await _unitOfWork.Repository<Material>().GetByIdAsync(request.MaterialId);
            if (material is null)
                throw new Exception("No Material Found");
            return material;
        }
    }
}