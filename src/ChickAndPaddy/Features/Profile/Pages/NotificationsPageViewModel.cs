﻿namespace ChickAndPaddy;

public class NotificationsPageViewModel : NavigationAwareBaseViewModel
{
    private readonly INotificationService notificationService;

    private const int PAGE_SIZE = 20;
    private int currentPage;
    private bool hasMoreItems;

    public NotificationsPageViewModel(
        INotificationService notificationService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.notificationService = notificationService;
    }

    public ObservableCollection<NotificationModel> Notifications { get; set; }
    public bool IsBusy { get; set; }
    public bool IsRefreshing { get; set; }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        LoadDataAsync(true).FireAndForget();
    }

    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        currentPage = forced ? 0 : currentPage + 1;

        var items = await notificationService.GetNotificationsAsync(currentPage, PAGE_SIZE);

        IsBusy = false;

        hasMoreItems = items.Count() >= PAGE_SIZE;

        if (Notifications == null)
        {
            Notifications = new ObservableCollection<NotificationModel>(items);
            return;
        } 

        if (forced)
        {
            Notifications.Clear();
        }

        foreach (var item in items)
        {
            Notifications.Add(item);
        }
    }

    ICommand _LoadMoreCommand;
    public ICommand LoadMoreCommand => _LoadMoreCommand ??= new Command(ExecuteLoadMoreCommand);
    private void ExecuteLoadMoreCommand() => LoadDataAsync(false).FireAndForget();

    ICommand _RefreshCommand;
    public ICommand RefreshCommand => _RefreshCommand ??= new Command(ExecuteRefreshCommand);
    private void ExecuteRefreshCommand() => LoadDataAsync(true)
        .ContinueWith(x => IsRefreshing = false)
        .FireAndForget();
}

