namespace Domoplat.Notifications.Contracts.Requests;

/// <summary>
/// Запрос на отправку уведомления
/// </summary>
public class BaseNotificationMessageRequest
{
    /// <summary>
    /// Тема уведомления
    /// </summary>
    public string Topic { get; set; }
    
    /// <summary>
    /// Текст уведомления
    /// </summary>
    public string Message { get; set; }
}