using Application.Specifications;
using Domain;

namespace Application.CarLoads;

public class GetCarLoadTodaySpecification : BaseSpecification<CarLoad>
{
    public GetCarLoadTodaySpecification()
        : base(car => car.CreatedAt.Date == DateTime.Today.Date)
    {
    }
}