using Bogus;

namespace ChickAndPaddy;

public class NotificationService : INotificationService
{
    private IEnumerable<NotificationModel> notifications;

    public Task<IEnumerable<NotificationModel>> GetNotificationsAsync(int pageIndex = 0, int pageSize = 20)
    {
        if (notifications?.Any() == true)
        {
            return Task.FromResult(GetItemsInGivenPage(pageIndex, pageSize));
        }

        return Task.Run(() =>
        {
            var faker = new Faker<NotificationModel>();
            faker.RuleFor(x => x.Id, setter => Guid.NewGuid());
            faker.RuleFor(x => x.Title, setter => setter.Lorem.Sentence(10, 15));
            faker.RuleFor(x => x.IconUrl, setter => setter.Image.LoremFlickrUrl(120, 120));
            notifications = faker.Generate(200);

            return GetItemsInGivenPage(pageIndex, pageSize);
        });
    }

    IEnumerable<NotificationModel> GetItemsInGivenPage(int pageIndex, int pageSize)
    {
        return notifications.Skip(pageIndex * pageSize).Take(pageSize); ;
    }
}

