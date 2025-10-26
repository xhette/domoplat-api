using Domoplat.Notifications.Contracts;
using Domoplat.Notifications.Contracts.Enums;
using Domoplat.Notifications.Contracts.Requests;
using Domoplat.Notifications.Contracts.Results;

namespace Domoplat.Notifications.Application.Interfaces;

/// <summary>
/// Рассылка уведомлений
/// </summary>
public interface INotificationSender
{
    /// <summary>
    /// Канал связи
    /// </summary>
    NotificationChanelType ChanelType { get; }
    
    /// <summary>
    /// Отправить
    /// </summary>
    /// <param name="messageRequest">Уведомление</param>
    /// <returns></returns>
    Task<SendNotificationResult> SendAsync(UserNotificationMessageRequest messageRequest);
}