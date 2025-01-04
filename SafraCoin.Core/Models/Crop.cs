namespace SafraCoin.Core.Models;

public class Crop
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Farmer Farmer { get; set; }
    public required string Name { get; set; }
    public decimal ExpectedYield { get; set; }
    public decimal ExpectedRevenue { get; set; }
    public decimal OperetionalCost { get; set; }
    public DateTime HarvestDate { get; set; }
    public decimal DistributionPercentage { get; set; }
}
