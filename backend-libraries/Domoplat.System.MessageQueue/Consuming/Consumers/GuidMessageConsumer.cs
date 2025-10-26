using Confluent.Kafka;
using Domoplat.System.MessageQueue.Config;
using Domoplat.System.MessageQueue.Consuming.Interfaces;
using Microsoft.Extensions.Logging;

namespace Domoplat.System.MessageQueue.Consuming.Consumers;

/// <summary>
/// Потребитель очереди сообщений с Guid ключом
/// </summary>
/// <typeparam name="TMessage">Тип сообщения</typeparam>
public class GuidMessageConsumer<TMessage> : MessageConsumer<Guid, TMessage>
{
    public GuidMessageConsumer(
        KafkaConfig kafkaConfig,
        ILogger<MessageConsumer<Guid, TMessage>> logger,
        IMessageConsumeHandler<TMessage> messageConsumeHandler,
        IDeserializer<TMessage> deserializer) 
        : base(kafkaConfig, logger, messageConsumeHandler, deserializer)
    {
    }
}