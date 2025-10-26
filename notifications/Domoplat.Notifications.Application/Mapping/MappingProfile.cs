using AutoMapper;
using Domoplat.Notifications.Contracts.MessageQueue;
using Domoplat.Notifications.Contracts.Requests;

namespace Domoplat.Notifications.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SendNotificationMessage, UserNotificationMessageRequest>();
        CreateMap(typeof(UserNotificationMessageRequest), typeof(ChanelNotificationMessageRequest<>));
    }
}