namespace SafraCoin.Core.ValueObjects;

public class CropTokenizeVO
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public decimal ExpectedYield { get; set; }
    public decimal ExpectedRevenue { get; set; }
    public decimal OperetionalCost { get; set; }
    public DateTime HarvestDate { get; set; }
    public decimal DistributionPercentage { get; set; }
    public uint TokenQuantity { get; set; }

    public CropTokenizeVO(
    Guid userId,
    string name,
    decimal expectedYield,
    decimal expectedRevenue,
    decimal operetionalCost,
    DateTime harvestDate,
    decimal distributionPercentage,
    uint tokenQuantity)
    {
        UserId = userId;
        Name = name;
        ExpectedYield = expectedYield;
        ExpectedRevenue = expectedRevenue;
        OperetionalCost = operetionalCost;
        HarvestDate = harvestDate;
        DistributionPercentage = distributionPercentage;
        TokenQuantity = tokenQuantity;
    }
}
