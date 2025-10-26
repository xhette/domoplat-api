namespace Domoplat.Notifications.Contracts.Enums;

/// <summary>
/// Тип канала связи
/// </summary>
public enum NotificationChanelType
{
    /// <summary>
    /// СМС
    /// </summary>
    Sms,
    
    /// <summary>
    /// Электронная почта
    /// </summary>
    Email,
    
    /// <summary>
    /// TG
    /// </summary>
    Telegram,
    
    /// <summary>
    /// Push-уведомления
    /// </summary>
    Push
}