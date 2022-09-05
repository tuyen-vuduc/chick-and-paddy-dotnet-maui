namespace ChickAndPaddy;

public interface INotificationService
{
    Task<IEnumerable<NotificationModel>> GetNotificationsAsync(int pageIndex, int pageSize);
}

