using Application.Specifications;
using Domain;

namespace Application.CarLoads;

public class GetCarLoadRangeSpecification:BaseSpecification<CarLoad>
{
    public GetCarLoadRangeSpecification(DateTime startDate, DateTime endDate ):base(carLoad=>
        carLoad.CreatedAt.Date>=startDate && carLoad.CreatedAt.Date<=endDate)
    {
        
    }
}