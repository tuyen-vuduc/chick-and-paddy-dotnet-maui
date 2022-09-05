namespace ChickAndPaddy.Tests.Features.Landing;

public class LandingPageViewModelTests : UnitTestBase<LandingPageViewModel>
{
    [Fact]
    public async Task OnAppearingAsync_ShouldNavigateToWalkthroughPage_AfterAppeared() {
        // Arrange

        // Act
        await Sut.OnAppearingAsync();

        // Assert
        var appNavigatorMock = Mocker.GetMock<IAppNavigator>();
        appNavigatorMock.Verify(
            x => x.NavigateAsync(AppRoutes.Walkthrough, It.IsAny<bool>(), It.IsAny<object>()),
            Times.Once
        );
    }
}

