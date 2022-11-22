using Bogus;
using Bogus.DataSets;

namespace ChickAndPaddy;

public class NewsFeedService : INewsFeedService
{
    private IEnumerable<NewsFeedModel> newsFeedItems;

    public Task<IEnumerable<NewsFeedModel>> GetNewsFeedsAsync(int pageIndex = 0, int pageSize = 20)
    {
        if (newsFeedItems?.Any() == true)
        {
            return Task.FromResult(GetItemsInGivenPage(pageIndex, pageSize));
        }

        return Task.Run(() =>
        {
            var faker = new Faker<NewsFeedModel>();
            faker.RuleFor(x => x.Id, setter => Guid.NewGuid());
            faker.RuleFor(x => x.Title, setter => setter.Lorem.Sentence(10, 15));
            faker.RuleFor(x => x.Content, setter => setter.Lorem.Paragraph());
            faker.RuleFor(x => x.AvatarUrl, setter => setter.Image.LoremFlickrUrl(120, 120, "nature"));
            faker.RuleFor(x => x.Location, setter => setter.Address.City());
            faker.RuleFor(x => x.CreatedAt, setter => setter.Date.Recent());

            faker.RuleFor(x => x.Photos, setter => NewsFeedService.GeneratePhotos());

            newsFeedItems = faker.Generate(200).OrderByDescending(x => x.CreatedAt).ToList();

            return GetItemsInGivenPage(pageIndex, pageSize);
        });
    }

    private static IEnumerable<PhotoModel> GeneratePhotos()
    {
        var faker = new Faker<PhotoModel>();
        faker.RuleFor(x => x.Url, setter => setter.Image.LoremFlickrUrl(keywords: "cat, dog, nature"));

        return faker.GenerateBetween(3, 7);
    }

    IEnumerable<NewsFeedModel> GetItemsInGivenPage(int pageIndex, int pageSize)
    {
        return newsFeedItems.Skip(pageIndex * pageSize).Take(pageSize);
    }
}

