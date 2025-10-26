using System.Text.Json;
using Confluent.Kafka;

namespace Domoplat.System.MessageQueue.Serializers;

public class MessageJsonSerializer<TMessage> : ISerializer<TMessage>
{
    public byte[] Serialize(TMessage data, SerializationContext context) => JsonSerializer.SerializeToUtf8Bytes(data);
}