using Domoplat.Notifications.Application.Interfaces;
using Domoplat.Notifications.Contracts.Enums;

namespace Domoplat.Notifications.Application.Implementations;

public class NotificationSenderFactory
{
    public Dictionary<NotificationChanelType, INotificationSender> NotificationSenders { get; }

    public NotificationSenderFactory(ICollection<INotificationSender> notificationSenders)
    {
        NotificationSenders = new Dictionary<NotificationChanelType, INotificationSender>();
    }
}