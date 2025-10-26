using AutoMapper;
using Domoplat.Notifications.Application.Interfaces;
using Domoplat.Notifications.Contracts.Configs;
using Domoplat.Notifications.Contracts.Enums;
using Domoplat.Notifications.Contracts.Requests;
using Domoplat.Notifications.Contracts.Results;
using Microsoft.Extensions.Logging;

namespace Domoplat.Notifications.Application.Implementations;

/// <summary>
/// Базовый класс отправки уведомлений
/// </summary>
public abstract class BaseNotificationSender<TContact> : INotificationSender
{
    public abstract NotificationChanelType ChanelType { get; }
    
    protected NotificationsConfig NotificationsConfig;
    protected ILogger<BaseNotificationSender<TContact>> Logger;
    
    private readonly IMapper _mapper;

    protected BaseNotificationSender(NotificationsConfig notificationsConfig, ILogger<BaseNotificationSender<TContact>> logger, IMapper mapper)
    {
        NotificationsConfig = notificationsConfig;
        Logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Отправка уведомления
    /// </summary>
    /// <param name="messageRequest">Запрос</param>
    /// <returns>Результат отправки сообщения</returns>
    public async Task<SendNotificationResult> SendAsync(UserNotificationMessageRequest messageRequest)
    {
        var contact = await GetChanelNotificationMessageRequest(messageRequest.UserId);

        var contactRequest = _mapper.Map<ChanelNotificationMessageRequest<TContact>>(messageRequest, opt =>
            opt.AfterMap(
                (source, dest) =>
                {
                    dest.Contact = contact;
                }));
        
        var response = new SendNotificationResult
        {
            ChanelType = ChanelType,
        };

        try
        {
            await SendInternal(contactRequest);

            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        
        return response;
    }
    
    /// <summary>
    /// Получить контактные данные для отправки
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <returns>Контакт пользователя для отправки уведомления</returns>
    protected abstract Task<TContact> GetChanelNotificationMessageRequest(Guid userId);
    
    /// <summary>
    /// Отправить уведомление
    /// </summary>
    /// <param name="request">Запрос</param>
    protected abstract Task SendInternal(ChanelNotificationMessageRequest<TContact> request);
}