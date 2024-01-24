namespace Domain;

public class Driver : BaseEntity
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string VehiclePlate { get; set; }
    public string VehicleModel { get; set; }
}