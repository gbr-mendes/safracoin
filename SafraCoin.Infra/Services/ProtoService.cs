using Google.Protobuf;
using SafraCoin.Core.Interfaces.Services;

namespace SafraCoin.Infra.Services;

public class ProtoService : IProtoService
{
    public byte[] Serialize<T>(T value) where T: IMessage<T>
    {
        using var stream = new MemoryStream();
        value.WriteTo(stream);
        return stream.ToArray();
    }
}
