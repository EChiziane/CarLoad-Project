namespace Domain;

public class CarLoadDto
{
    public int Id { get; set; }
    public string Destination { get; set; }
    public decimal Earnings { get; set; }
    public decimal FuelExpense { get; set; }
    public decimal PoliceExpense { get; set; }
    public string Client { get; set; }
    public string Manager { get; set; }
    public string Material { get; set; }
    public string Driver { get; set; }
}