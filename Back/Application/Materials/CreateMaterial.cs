using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;

namespace Application.Materials;

public class CreateMaterial
{
    public class CreateMaterialCommand : IRequest<Material>
    {
        public string Type { get; set; }
    }

    public class CrateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
    {
        public CrateMaterialCommandValidator()
        {
            RuleFor(x => x.Type).NotEmpty().NotNull();
        }
    }

    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, Material>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMaterialCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Material> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var material = new Material
            {
                Type = request.Type
            };

            _unitOfWork.Repository<Material>().Add(material);
            var result = await _unitOfWork.Complete() > 0;
            if (result) return material;
            throw new Exception("problem saving");
        }
    }
}