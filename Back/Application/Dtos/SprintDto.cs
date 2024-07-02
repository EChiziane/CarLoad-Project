namespace Application.Dtos;

public class SprintDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; } // Assuming SprintStatus is an enum

    public int NumberCarLoad { get; set; }
    public string DriverName { get; set; } // Assuming Driver has a Name property
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string LastUpdatedBy { get; set; }
}