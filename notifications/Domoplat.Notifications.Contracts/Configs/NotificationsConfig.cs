namespace Domoplat.Notifications.Contracts.Configs;

public class NotificationsConfig
{
    /// <summary>
    /// Email отправителя
    /// </summary>
    public string EmailFrom { get; set; }
    
    /// <summary>
    /// SMTP
    /// </summary>
    public SmtpConfig SmtpConfig { get; set; }
}