using Domain;

namespace Application.Specifications.Carloads;

public class GetCarLoadsSpecification : BaseSpecification<CarLoad>
{
    public GetCarLoadsSpecification()
    {
        AddInclude(x => x.Driver);
        AddInclude(x => x.Manager);
        AddInclude(x => x.Material);
        AddInclude(x => x.Sprint);
    }
}