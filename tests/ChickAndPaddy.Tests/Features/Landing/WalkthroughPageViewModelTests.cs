namespace ChickAndPaddy.Tests.Features.Landing;

public class WalkthroughPageViewModelTests : UnitTestBase<WalkthroughPageViewModel>
{
    [Fact]
    public async Task OnInit_ShouldInitializedWalkthroughItems()
    {
        // Arrange
        var landingServiceMock = Mocker.GetMock<ILandingService>();
        landingServiceMock.Setup(x => x.GetWalkthroughItemsAsync())
            .ReturnsAsync(new WalkthroughItemModel[] {
                new WalkthroughItemModel(),
                new WalkthroughItemModel(),
                new WalkthroughItemModel(),
            });

        // Act
        Sut.ApplyQueryAttributes(new Dictionary<string, object>());

        // Simulates internal call to Async method
        await Task.Delay(500);

        // Assert
        Assert.True(Sut.Items.Count > 0);
        Assert.True(Sut.AllowsToContinue);
        Assert.True(Sut.AllowsToSkip);
        Assert.False(Sut.AllowsToStart);
        Assert.False(Sut.AllowsToGoback);
    }

    [Theory]
    [InlineData(0, true, true, false, false)]
    [InlineData(1, true, true, false, true)]
    [InlineData(2, false, false, true, true)]
    public async Task ItemPosition_ShouldImpactOtherFlagsWhenChanging(
        int position,
        bool allowsToContinue,
        bool allowsToSkip,
        bool allowsToStart,
        bool allowsToGoback)
    {
        // Arrange
        var landingServiceMock = Mocker.GetMock<ILandingService>();
        landingServiceMock.Setup(x => x.GetWalkthroughItemsAsync())
            .ReturnsAsync(new WalkthroughItemModel[] {
                new WalkthroughItemModel(),
                new WalkthroughItemModel(),
                new WalkthroughItemModel(),
            });

        Sut.ApplyQueryAttributes(new Dictionary<string, object>());

        // Simulates internal call to Async method
        await Task.Delay(500);

        // Act
        Sut.ItemPosition = position;

        // Assert
        Assert.True(Sut.Items.Count > 0);
        Assert.Equal(allowsToContinue, Sut.AllowsToContinue);
        Assert.Equal(allowsToSkip, Sut.AllowsToSkip);
        Assert.Equal(allowsToStart, Sut.AllowsToStart);
        Assert.Equal(allowsToGoback, Sut.AllowsToGoback);
    }
}

