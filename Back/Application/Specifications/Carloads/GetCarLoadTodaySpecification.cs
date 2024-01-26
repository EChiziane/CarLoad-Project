using Application.Specifications;
using Domain;

namespace Application.CarLoads;

public class GetCarLoadTodaySpecification:BaseSpecification<CarLoad>
{
    public GetCarLoadTodaySpecification()
        :base(car=>car.CreatedAt.Substring(0,10).Equals(DateTime.Now.ToString("yyyy-M-d")))
    {
        
    }
}