using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Font = Microsoft.Maui.Font;

namespace ChickAndPaddy;

[ExcludeFromCodeCoverage]
public class AppNavigator : IAppNavigator
{
    private readonly IServiceProvider serviceProvider;

    public AppNavigator(
        IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task GoBackAsync(bool animated = false, object data = default)
    {
        return NavigateAsync(UriHelper.GoBackSegment, animated, data);
    }

    public Task NavigateAsync(string target, bool animated = false, object args = default)
    {
        var navArgs = new Dictionary<string, object>()
        {
            { "source", Shell.Current.CurrentState.Location.OriginalString },
            { nameof(target), target },
            { nameof(animated), animated }
        };

        if (args is not null)
        {
            navArgs.Add(UriHelper.DataQueryParameterName, args);
        }

        if (target == UriHelper.GoBackSegment)
        {
            navArgs.Add(UriHelper.GoBackQueryParameterName, true);
        }

        return MainThread.InvokeOnMainThreadAsync(() => Shell.Current.GoToAsync(
            target,
            animated,
            navArgs
        ).ContinueWith(x =>
        {

        }));
    }

    public Task<bool> OpenUrlAsync(string url)
    {
        return Launcher.OpenAsync(url);
    }

    public Task ShareAsync(string text, string title = default)
    {
        var request = new ShareTextRequest(text, title);

        return Share.Default.RequestAsync(request);
    }

    public Task ShowSnackbarAsync(string message, Action action = null, string actionText = null)
    {
        var options = new SnackbarOptions
        {
            BackgroundColor = AppColors.Purple,
            TextColor = AppColors.White,
            ActionButtonTextColor = AppColors.Pink,
            CornerRadius = new CornerRadius(Dimens.ButtonCornerRadius),
            Font = Font.OfSize(FontNames.ArchiaRegular, Dimens.FontSizeT6),
            ActionButtonFont = Font.OfSize(FontNames.ArchiaSemiBold, Dimens.FontSizeT6),
            CharacterSpacing = 0.5
        };
        var snackbar = Snackbar.Make(message, action, actionText ?? "OK", TimeSpan.FromSeconds(5), options);
        return snackbar.Show();
    }
}
