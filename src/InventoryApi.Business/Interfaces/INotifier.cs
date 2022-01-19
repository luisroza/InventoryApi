using System.Collections.Generic;
using InventoryApi.Business.Notifications;

namespace InventoryApi.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}