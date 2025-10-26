using Confluent.Kafka;
using Domoplat.System.MessageQueue.Config;
using Domoplat.System.MessageQueue.Consuming.Consumers;
using Domoplat.System.MessageQueue.Consuming.Interfaces;
using Domoplat.System.MessageQueue.Producing.Interfaces;
using Domoplat.System.MessageQueue.Producing.Producers;
using Domoplat.System.MessageQueue.Serializers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Domoplat.System.MessageQueue.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKaffkaOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<KafkaConfig>(configuration.GetSection(nameof(KafkaConfig)));
        serviceCollection.AddSingleton(sp => sp.GetRequiredService<IOptions<KafkaConfig>>().Value);
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddGuidMessageProducer<TMessage>(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ISerializer<TMessage>, MessageJsonSerializer<TMessage>>();
        serviceCollection.AddSingleton<IMessageProducer<Guid, TMessage>, GuidMessageProducer<TMessage>>();
        
        return serviceCollection;
    }
    
    public static IServiceCollection AddGuidMessageConsumer<TMessage, THandler>(this IServiceCollection serviceCollection) where THandler : class, IMessageConsumeHandler<TMessage>
    {
        serviceCollection.AddHostedService<GuidMessageConsumer<TMessage>>();
        serviceCollection.AddSingleton<IDeserializer<TMessage>, MessageJsonDeserializer<TMessage>>();
        serviceCollection.AddSingleton<IMessageConsumeHandler<TMessage>, THandler>();
        
        return serviceCollection;
    }
}