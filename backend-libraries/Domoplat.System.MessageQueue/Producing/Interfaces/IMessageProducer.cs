namespace Domoplat.System.MessageQueue.Producing.Interfaces;

public interface IMessageProducer<in TKey, in TMessage>
{
    Task ProduceAsync(TMessage message, CancellationToken cancellationToken);
}