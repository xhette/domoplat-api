using Confluent.Kafka;
using Domoplat.System.MessageQueue.Config;
using Domoplat.System.MessageQueue.Consuming.Consumers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Domoplat.System.MessageQueue.Producing.Producers;

public class GuidMessageProducer<TMessage> : MessageProducer<Guid, TMessage>
{
    public GuidMessageProducer(
        KafkaConfig kafkaConfig,
        ILogger<MessageConsumer<Guid, TMessage>> logger,
        ISerializer<TMessage> serializer)
        : base(kafkaConfig, logger, serializer)
    {
    }

    protected override Guid GetKey() => Guid.NewGuid();
}