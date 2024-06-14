using Domain;

namespace Application.Specifications;

public class GetSprintByIdSpecification : BaseSpecification<Sprint>
{
    public GetSprintByIdSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Driver);
    }
}