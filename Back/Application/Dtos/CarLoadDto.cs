namespace Domain;

public class CarLoadDto
{
    public int Id { get; set; }
    public string Destination { get; set; }
    public decimal Earnings { get; set; }
    public decimal FuelExpense { get; set; }
    public decimal PoliceExpense { get; set; }
    public string ClientName { get; set; }
    public string ClientNumber { get; set; }
    public string Sprint { get; set; }
    public string ManagerName { get; set; }
    public string MaterialName { get; set; }
    public string DriverName { get; set; }
    public decimal DriverExpenses { get; set; }
    public decimal Expenses { get; set; }
    public decimal ManagerExpenses { get; set; }
    public decimal Toll { get; set; }
    public int PurchaseMoney { get; set; }
    public DateTime CreatedAt { get; set; }
}