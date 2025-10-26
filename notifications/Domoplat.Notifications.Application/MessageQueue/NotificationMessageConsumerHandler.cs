using AutoMapper;
using Domoplat.Notifications.Application.Implementations;
using Domoplat.Notifications.Contracts.MessageQueue;
using Domoplat.Notifications.Contracts.Requests;
using Domoplat.System.MessageQueue.Consuming.Interfaces;

namespace Domoplat.Notifications.Application.MessageQueue;

/// <summary>
/// Обработка очереди сообщений
/// </summary>
public class NotificationMessageConsumerHandler : IMessageConsumeHandler<SendNotificationMessage>
{
    private readonly NotificationSenderFactory _notificationSenderFactory;
    private readonly IMapper _mapper;

    public NotificationMessageConsumerHandler(NotificationSenderFactory notificationSenderFactory, IMapper mapper)
    {
        _notificationSenderFactory = notificationSenderFactory;
        _mapper = mapper;
    }

    public async Task Handle(SendNotificationMessage message, CancellationToken cancellationToken)
    {
        var notificationSender = _notificationSenderFactory.NotificationSenders[message.ChanelType] ?? throw new Exception("Unknown notification chanel type");
        
        var notificationRequest = _mapper.Map<UserNotificationMessageRequest>(message);
        await notificationSender.SendAsync(notificationRequest);
    }
}