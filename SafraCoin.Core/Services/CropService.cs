using Optional.Unsafe;
using SafraCoin.Core.Exceptions;
using SafraCoin.Core.Interfaces.Repositories;
using SafraCoin.Core.Interfaces.Repositories.EFRepository;
using SafraCoin.Core.Interfaces.Services;
using SafraCoin.Core.Models;
using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Services;

public class CropService : ICropService
{
    private readonly ICropRepository _cropRepository;
    private readonly IFarmerRepository _farmerRepository;
    private readonly IRedisRepository _redisRepository;
    private readonly IProtoService _protoService;
    private const string StreamKey = "CropsToTokenize";

    public CropService(
        ICropRepository cropRepository,
        IFarmerRepository farmerRepository,
        IRedisRepository redisRepository,
        IProtoService protoService)
    {
        _cropRepository = cropRepository;
        _farmerRepository = farmerRepository;
        _redisRepository = redisRepository;
        _protoService = protoService;
    }

    public async Task<bool> Tokenize(CropTokenizeVO cropTokenizeVO)
    {
        var farmer = await _farmerRepository.GetFarmerByUserId(cropTokenizeVO.UserId);
        if (!farmer.HasValue)
        {
            throw new DomainException($"Farmer related to user of id {cropTokenizeVO.UserId} not found");
        }

        var crop = new Crop
        {
            Name = cropTokenizeVO.Name,
            ExpectedYield = cropTokenizeVO.ExpectedYield,
            ExpectedRevenue = cropTokenizeVO.ExpectedRevenue,
            OperetionalCost = cropTokenizeVO.OperetionalCost,
            HarvestDate = cropTokenizeVO.HarvestDate,
            DistributionPercentage = cropTokenizeVO.DistributionPercentage,
            Farmer = farmer.ValueOrFailure(),
        };

        var cropAdded = await _cropRepository.AddCrop(crop);

        if (!cropAdded)
        {
            throw new DomainException("An error has occurred while adding crop to database");
        }

        var redisEntry = new CropTokenizeRequest
        {
          CropId = crop.Id.ToString(),
          TokenQuantity = cropTokenizeVO.TokenQuantity,
          IntitialPrice = CalculateIntialPrice(
            cropTokenizeVO.ExpectedRevenue,
            cropTokenizeVO.OperetionalCost,
            cropTokenizeVO.DistributionPercentage,
            cropTokenizeVO.TokenQuantity
          ),
          FarmerAccountAddress = farmer.ValueOrFailure().AccountAddress  
        };

        var serializedEntry = _protoService.Serialize(redisEntry);

        await _redisRepository.AddEntryToStreamAsync(StreamKey, serializedEntry);

        return true;
    }

    private static ulong CalculateIntialPrice(decimal expectedRevenue, decimal operationalCost, decimal distributionPercentage, ulong tokenQuantity)
    {
        var initialPrice = (expectedRevenue - operationalCost) * distributionPercentage / tokenQuantity;
        var scaledPrice = initialPrice * 100;
        return (ulong) Math.Round(scaledPrice);
    }
}
