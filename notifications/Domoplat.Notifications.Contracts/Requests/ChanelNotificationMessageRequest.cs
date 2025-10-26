namespace Domoplat.Notifications.Contracts.Requests;

public class ChanelNotificationMessageRequest<TContact> : BaseNotificationMessageRequest
{
    public TContact Contact { get; set; }
}