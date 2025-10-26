using Domoplat.Notifications.Contracts.Enums;

namespace Domoplat.Notifications.Contracts.Results;

/// <summary>
/// Результат отправки уведомления
/// </summary>
public class SendNotificationResult
{
    public NotificationChanelType ChanelType { get; set; }
    
    public bool Success { get; set; }
    
    public string? ErrorMessage { get; set; }
}