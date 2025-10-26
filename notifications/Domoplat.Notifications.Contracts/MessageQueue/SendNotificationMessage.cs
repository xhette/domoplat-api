using Domoplat.Notifications.Contracts.Enums;

namespace Domoplat.Notifications.Contracts.MessageQueue;

public class SendNotificationMessage
{
    /// <summary>
    /// Тип канала связи
    /// </summary>
    public NotificationChanelType ChanelType { get; set; }
    
    /// <summary>
    /// Тема уведомления
    /// </summary>
    public string Topic { get; set; }
    
    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}