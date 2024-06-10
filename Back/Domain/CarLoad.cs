using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class CarLoad : BaseEntity
{
    public string Destination { get; set; }
    public decimal Earnings { get; set; }
    public decimal FuelExpense { get; set; }
    public decimal PoliceExpense { get; set; }
    public decimal Toll { get; set; }
    public decimal DriverExpenses { get; set; }
    public decimal ManagerExpenses { get; set; }
    public decimal PurchaseMoney { get; set; }
        
    public decimal TotalExpenses 
    { 
        get
        {
            return FuelExpense + PoliceExpense + Toll + DriverExpenses + ManagerExpenses + PurchaseMoney;
        }
    }

    public int DriverId { get; set; }

    [ForeignKey("DriverId")] public Driver Driver { get; set; }

    public int ManagerId { get; set; }

    [ForeignKey("ManagerId")] public Manager Manager { get; set; }

    public int ClientId { get; set; }

    [ForeignKey("ClientId")] public Client Client { get; set; }

    public int MaterialId { get; set; }

    [ForeignKey("MaterialId")] public Material Material { get; set; }
}