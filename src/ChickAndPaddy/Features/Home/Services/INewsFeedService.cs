namespace ChickAndPaddy;

public interface INewsFeedService
{
    Task<IEnumerable<NewsFeedModel>> GetNewsFeedsAsync(int pageIndex, int pageSize);
}

