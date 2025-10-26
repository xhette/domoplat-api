namespace Domoplat.Notifications.Contracts.Configs;

/// <summary>
/// Конфиги SMTP
/// </summary>
public class SmtpConfig
{
    /// <summary>
    /// Сервер
    /// </summary>
    public string Server { get; set; }
    
    /// <summary>
    /// Порт
    /// </summary>
    public int Port { get; set; }
    
    /// <summary>
    /// Логин
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
}