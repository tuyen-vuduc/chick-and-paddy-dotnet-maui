﻿namespace ChickAndPaddy;

public partial class SettingsAndHelpPageViewModel(
        IAppSettingsService appSettings,
        IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
{
    private readonly IAppSettingsService appSettings = appSettings;

    [RelayCommand]
    private Task CancelRelationshipAsync()
    {
        appSettings.InARelationship = false;
        return AppNavigator.NavigateAsync(AppRoutes.Home);
    }

    [RelayCommand]
    private Task ViewSettingsAsync() => AppNavigator.NavigateAsync(AppRoutes.Settings);

    [RelayCommand]
    private Task ViewNotificationsAsync() => AppNavigator.NavigateAsync(AppRoutes.Notifications);

    [RelayCommand]
    private void Support()
    {

    }

    [RelayCommand]
    private Task SignOut()
    {
        appSettings.Clear();
        return AppNavigator.NavigateAsync(AppRoutes.SignIn);
    }
}

