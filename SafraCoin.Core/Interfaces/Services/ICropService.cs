using SafraCoin.Core.ValueObjects;

namespace SafraCoin.Core.Interfaces.Services;

public interface ICropService
{
    Task<bool> Tokenize(CropTokenizeVO cropTokenizeVO);
}
