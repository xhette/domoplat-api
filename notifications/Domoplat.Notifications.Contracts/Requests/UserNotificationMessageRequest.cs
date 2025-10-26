namespace Domoplat.Notifications.Contracts.Requests;

public class UserNotificationMessageRequest : BaseNotificationMessageRequest
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}