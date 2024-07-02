using Domain;

namespace Application.Specifications;

public class GetClientByPhoneNumberSpecification : BaseSpecification<Client>
{
    public GetClientByPhoneNumberSpecification(string phoneNumber) : base(x =>
        x.PhoneNumber.ToUpper() == phoneNumber.ToUpper())
    {
        AddInclude(x => x.CreatedByUser);
    }
}