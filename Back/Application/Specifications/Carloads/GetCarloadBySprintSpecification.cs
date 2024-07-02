using Domain;

namespace Application.Specifications.Carloads;

public class GetCarloadBySprintSpecification : BaseSpecification<CarLoad>
{
    public GetCarloadBySprintSpecification(int sprintId) : base(x => x.SprintId == sprintId)
    {
        AddInclude(x => x.Driver);
        AddInclude(x => x.Manager);
        AddInclude(x => x.Material);
        AddInclude(x => x.Sprint);
    }
}