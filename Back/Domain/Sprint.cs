using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain;

public class Sprint : BaseEntity
{
    private const int MaxCarLoads = 18;

    public Sprint()
    {
        CarLoads = new List<CarLoad>();
    }

    public string Name { get; set; }
    public SprintStatus Status { get; }

    [JsonIgnore] public List<CarLoad> CarLoads { get; set; }


    public int DriverId { get; set; }
    [ForeignKey("DriverId")] public Driver Driver { get; set; }
}