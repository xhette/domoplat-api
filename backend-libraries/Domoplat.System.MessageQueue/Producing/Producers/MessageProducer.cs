using Confluent.Kafka;
using Domoplat.System.MessageQueue.Config;
using Domoplat.System.MessageQueue.Consuming.Consumers;
using Domoplat.System.MessageQueue.Producing.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Domoplat.System.MessageQueue.Producing.Producers;

public abstract class MessageProducer<TKey, TMessage> : IMessageProducer<TKey, TMessage>
{
    private readonly KafkaConfig _kafkaConfig;
    private readonly ILogger<MessageConsumer<TKey, TMessage>> _logger;
    private readonly ISerializer<TMessage> _serializer;
    
    private readonly string _topic;
    
    public MessageProducer(
        KafkaConfig kafkaConfig,
        ILogger<MessageConsumer<TKey, TMessage>> logger, ISerializer<TMessage> serializer)
    {
        _kafkaConfig = kafkaConfig;
        _logger = logger;
        _serializer = serializer;

        _topic = typeof(TMessage).Name;
    }
    
    public async Task ProduceAsync(TMessage message, CancellationToken cancellationToken)
    {
        var producer = BuildProducer();
        
        await producer.ProduceAsync(_topic, new Message<TKey, TMessage>
        {
            Key = GetKey(),
            Value = message,
        }, cancellationToken);
    }

    private IProducer<TKey, TMessage> BuildProducer()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = _kafkaConfig.BootstrapServers,
            AllowAutoCreateTopics = true,
        };
        
        return new ProducerBuilder<TKey, TMessage>(config)
            .SetValueSerializer(_serializer)
            .Build();
    }
    
     protected abstract TKey GetKey();
}