using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace Domoplat.System.MessageQueue.Serializers;

public class MessageJsonDeserializer<TMessage> : IDeserializer<TMessage>
{
    public TMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        var messageString = Encoding.UTF8.GetString(data.ToArray());
        return JsonSerializer.Deserialize<TMessage>(messageString)!;
    }
}