namespace ChickAndPaddy;

public partial class HomePageViewModel : NavigationAwareBaseViewModel
{
    const int PAGE_SIZE = 10;
    private readonly IProfileService profileService;
    private readonly INewsFeedService newsFeedService;

    private int currentPage;
    private bool hasMoreItems;

    public HomePageViewModel(
        IProfileService profileService,
        INewsFeedService newsFeedService,
        IAppNavigator appNavigator)
        : base(appNavigator)
    {
        this.profileService = profileService;
        this.newsFeedService = newsFeedService;
    }

    [ObservableProperty]
    string coupleCoverUrl;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DaysSinceMet))]
    PartnerModel partner;

    public int DaysSinceMet { get => ((DateTime.Today - Partner?.FirstMet.Date)?.Days ?? 0) + 1; }

    [ObservableProperty]
    ObservableCollection<NewsFeedModel> newsFeeds;

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    HomeItemType itemType = HomeItemType.CoupleMilestoneExpanded;

    [ObservableProperty]
    HomeTab homeTab = HomeTab.OurStories;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NoRelationship))]
    bool hasRelationship;

    public bool NoRelationship => !HasRelationship;

    protected override void OnInit(IDictionary<string, object> query)
    {
        base.OnInit(query);

        CoupleCoverUrl = "https://www.notariesofeurope.eu/wp-content/uploads/2021/07/couple3_header_cnue_notaireeurope.jpg";

        Partner = new PartnerModel
        {
            Id = Guid.NewGuid(),
            PairingId = "896958",
            NickName = "Gà con",

            FirstName = "Elon",
            LastName = "Musk",

            FirstMet = DateTime.Today.AddDays(-255),
        };
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        HasRelationship = await profileService.CheckRelationshipAsync();

        LoadDataAsync(true)
            .FireAndForget();
    }

    private async Task LoadDataAsync(bool forced)
    {
        if (IsBusy) return;
        IsBusy = true;

        currentPage = forced ? 0 : currentPage + 1;

        var items = await newsFeedService.GetNewsFeedsAsync(currentPage, PAGE_SIZE);

        IsBusy = false;

        hasMoreItems = items.Count() >= PAGE_SIZE;

        if (NewsFeeds == null || forced)
        {
            NewsFeeds = new ObservableCollection<NewsFeedModel>(items);
            return;
        }

        foreach (var item in items)
        {
            NewsFeeds.Add(item);
        }
    }

    [RelayCommand]
    private void LoadMore() => LoadDataAsync(false).FireAndForget();

    [RelayCommand]
    private void Refresh() => LoadDataAsync(true)
        .ContinueWith(x => IsRefreshing = false)
        .FireAndForget();

    [RelayCommand]
    private Task PairAsync() => AppNavigator.NavigateAsync(AppRoutes.Pair);

    [RelayCommand]
    private Task ViewNotificationsAsync() => AppNavigator.NavigateAsync(AppRoutes.Notifications);

    [RelayCommand]
    void ChangeMode()
    {
        switch (ItemType)
        {
            case HomeItemType.CoupleMilestoneExpanded:
                ItemType = HomeItemType.CoupleMilestoneCollapsed;
                break;
            case HomeItemType.CoupleMilestoneCollapsed:
                ItemType = HomeItemType.CoupleMilestoneExpanded;
                break;
        }
        NewsFeeds = new ObservableCollection<NewsFeedModel>(NewsFeeds);
    }

    [RelayCommand]
    void ChangeTab(HomeTab selectedTab)
    {
        if (selectedTab == HomeTab) return;

        switch (selectedTab)
        {
            case HomeTab.MyWall:
                HomeTab = HomeTab.MyWall;
                ItemType = HomeItemType.Story;
                break;
            case HomeTab.OurStories:
                HomeTab = HomeTab.OurStories;
                ItemType = HomeItemType.CoupleMilestoneExpanded;
                break;
        }

        NewsFeeds = new ObservableCollection<NewsFeedModel>(NewsFeeds);
    }

    [RelayCommand]
    void CreateStory()
    {

    }
}

