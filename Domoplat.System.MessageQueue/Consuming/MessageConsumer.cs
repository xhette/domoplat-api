using System.Net;
using Confluent.Kafka;
using Domoplat.System.MessageQueue.Config;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Domoplat.System.MessageQueue.Consuming;

public class MessageConsumer<TKey, TMessage> : BackgroundService
{
    private readonly IOptions<KafkaConfig> _kafkaConfig;
    private readonly ILogger<MessageConsumer<TKey, TMessage>> _logger;
    private readonly IMessageConsumeHandler<TMessage> _messageConsumeHandler;
    
    private readonly string _topic;

    public MessageConsumer(
        IOptions<KafkaConfig> kafkaConfig,
        ILogger<MessageConsumer<TKey, TMessage>> logger, IMessageConsumeHandler<TMessage> messageConsumeHandler)
    {
        _logger = logger;
        _messageConsumeHandler = messageConsumeHandler;
        _kafkaConfig = kafkaConfig;
        _topic = typeof(TMessage).Name;
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.Run(() => ConsumeAsync(stoppingToken), stoppingToken);

    private async Task ConsumeAsync(CancellationToken stoppingToken)
    {
        if (!TopicExists())
        {
            _logger.LogInformation($"Topic {_topic} does not exist.");
        }
        
        var consumer = BuildConsumer();
        
        consumer.Subscribe(_topic);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = consumer.Consume(stoppingToken);
                await _messageConsumeHandler.Handle(message.Message.Value, stoppingToken);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Error while consuming topic {_topic}.");
            throw;
        }
    }

    private bool TopicExists()
    {
        var clientConfig = BuildClientConfig();
        
        using var adminClient = new AdminClientBuilder(new AdminClientConfig(clientConfig)).Build();
        try
        {
            var metadata = adminClient.GetMetadata(_topic, TimeSpan.FromSeconds(10));
            return metadata.Topics.Any(t => t.Topic == _topic && t.Error.Code == ErrorCode.NoError);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking if topic {Topic} exists.", _topic);
            return false;
        }
    }
    
    private ClientConfig BuildClientConfig() => new ClientConfig
    {
        BootstrapServers = _kafkaConfig.Value.BootstrapServers,
        AllowAutoCreateTopics = true,
        ClientId = Dns.GetHostName()
    };

    private IConsumer<TKey, TMessage> BuildConsumer()
    {
        
        var config = new ConsumerConfig
        {
            BootstrapServers = _kafkaConfig.Value.BootstrapServers,
            GroupId = _kafkaConfig.Value.GroupId
        };
        
        return new ConsumerBuilder<TKey, TMessage>(config).Build();
    }
}
