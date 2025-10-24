namespace Domoplat.System.MessageQueue.Consuming;

public interface IMessageConsumeHandler<TMessage>
{
    Task Handle(TMessage message, CancellationToken cancellationToken);
}