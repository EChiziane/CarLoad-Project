using Domain;

namespace Application.Specifications;

public class GetSprintSpecification : BaseSpecification<Sprint>
{
    public GetSprintSpecification()
    {
        AddInclude(x => x.Driver);
    }
}