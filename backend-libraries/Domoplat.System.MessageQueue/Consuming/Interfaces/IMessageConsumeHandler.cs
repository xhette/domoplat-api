namespace Domoplat.System.MessageQueue.Consuming.Interfaces;

public interface IMessageConsumeHandler<TMessage>
{
    Task Handle(TMessage message, CancellationToken cancellationToken);
}