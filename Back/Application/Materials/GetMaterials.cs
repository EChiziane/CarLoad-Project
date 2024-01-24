using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Materials;

public class ListMaterials
{
    public class ListMaterialsQuery : IRequest<List<Material>>
    {
    }

    public class ListMaterialsQueryHandler : IRequestHandler<ListMaterialsQuery, List<Material>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListMaterialsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Material>> Handle(ListMaterialsQuery request, CancellationToken cancellationToken)
        {
            var materials = await _unitOfWork.Repository<Material>().ListAllAsync();
            return materials;
        }
    }
}