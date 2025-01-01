using Google.Protobuf;

namespace SafraCoin.Core.Interfaces.Services;

public interface IProtoService
{
    public byte[] Serialize<T>(T value) where T: IMessage<T>;
}
