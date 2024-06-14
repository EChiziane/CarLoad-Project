using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Sprint : BaseEntity
{
    private const int MaxCarLoads = 18;
    public string Name { get; set; }
    public SprintStatus Status { get; }
    public int DriverId { get; set; }
    [ForeignKey("DriverId")] public Driver Driver { get; set; }
}