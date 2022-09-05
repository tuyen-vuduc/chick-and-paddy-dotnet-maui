namespace ChickAndPaddy;

public interface ILandingService
{
    Task<IEnumerable<WalkthroughItemModel>> GetWalkthroughItemsAsync();
}