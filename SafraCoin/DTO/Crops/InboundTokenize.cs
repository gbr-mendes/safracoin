using System.ComponentModel.DataAnnotations;

namespace SafraCoin.DTO.Crops;

public class InboundTokenize
{
    [Required]
    public required string Name { get; set;}
    [Required]
    public decimal ExpectedYield { get; set; }
    [Required]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "ExpectedRevenue must have at most two decimal places.")]
    public decimal ExpectedRevenue { get; set; }
    [Required]
    public decimal OperetionalCost { get; set; }
    [Required]
    public DateTime HarvestDate { get; set; }
    [Required]
    [Range(0.5, 1, ErrorMessage = "Distribution percentage must be between 0.5 and 1")]
    public decimal DistributionPercentage { get; set; }
    [Required]
    [Range(10000, 100000000, ErrorMessage = "Token quantity must be between 10000 and 100000000")]
    public uint TokenQuantity { get; set; }
}
