using AutoMapper;
using Domoplat.Notifications.Contracts.Configs;
using Domoplat.Notifications.Contracts.Enums;
using Domoplat.Notifications.Contracts.Requests;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Domoplat.Notifications.Application.Implementations;

/// <summary>
/// Отправка e-mail
/// </summary>
public class EmailNotificationSender : BaseNotificationSender<string>
{
    private readonly ISmtpClient _smtpClient;
    
    public override NotificationChanelType ChanelType => NotificationChanelType.Email;
    
    public EmailNotificationSender(
        ISmtpClient smtpClient,
        NotificationsConfig notificationsConfig,
        ILogger<EmailNotificationSender> logger,
        IMapper mapper) 
        : base(notificationsConfig, logger, mapper)
    {
        _smtpClient = smtpClient;
    }
    
    /// <inheritdoc />
    protected override Task<string> GetChanelNotificationMessageRequest(Guid userId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    protected override async Task SendInternal(ChanelNotificationMessageRequest<string> request)
    {
        await _smtpClient.ConnectAsync(NotificationsConfig.SmtpConfig.Server, NotificationsConfig.SmtpConfig.Port, false);
        await _smtpClient.AuthenticateAsync(NotificationsConfig.SmtpConfig.Username, NotificationsConfig.SmtpConfig.Password);
        
        var message = BuildMessage(request);
        
        await _smtpClient.SendAsync(message);
        await _smtpClient.DisconnectAsync(true);
        
    }

    private MimeMessage BuildMessage(ChanelNotificationMessageRequest<string> request)
    {
        var message = new MimeMessage();
        
        message.From.Add(new MailboxAddress(NotificationsConfig.EmailFrom, NotificationsConfig.EmailFrom));
        message.To.Add(new MailboxAddress(request.Contact, request.Contact));
        
        message.Subject = request.Topic;
        message.Body = new TextPart ("plain") { Text = request.Message };
        
        return message;
    }
}