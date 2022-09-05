namespace ChickAndPaddy;

public class HomePageViewModel : NavigationAwareBaseViewModel
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

    public string CoupleCoverUrl { get; set; }
    public PartnerModel Partner { get; set; }
    public int DaysSinceMet { get => ((DateTime.Today - Partner?.FirstMet.Date)?.Days ?? 0) + 1; }

    public ObservableCollection<NewsFeedModel> NewsFeeds { get; set; }
    public bool IsBusy { get; set; }
    public bool IsRefreshing { get; set; }
    public HomeItemType ItemType { get; set; } = HomeItemType.CoupleMilestoneExpanded;
    public HomeTab HomeTab { get; set; } = HomeTab.OurStories;

    public bool HasRelationship { get; set; }
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

        if (NewsFeeds == null)
        {
            NewsFeeds = new ObservableCollection<NewsFeedModel>(items);
            return;
        }

        if (forced)
        {
            NewsFeeds.Clear();
        }

        foreach (var item in items)
        {
            NewsFeeds.Add(item);
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

    ICommand _PairCommand;
    public ICommand PairCommand => _PairCommand ??= new Command(ExecutePairCommand);
    private void ExecutePairCommand()
    {
        AppNavigator.NavigateAsync(AppRoutes.Pair);
    }

    ICommand _ViewNotificationsCommand;
    public ICommand ViewNotificationsCommand => _ViewNotificationsCommand ??= new Command(ExecuteViewNotificationsCommand);
    private void ExecuteViewNotificationsCommand()
    {
        AppNavigator.NavigateAsync(AppRoutes.Notifications);
    }

    ICommand _ChangeModeCommand;
    public ICommand ChangeModeCommand => _ChangeModeCommand ??= new Command(ExecuteChangeModeCommand);
    void ExecuteChangeModeCommand()
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

    ICommand _ChangeTabCommand;
    public ICommand ChangeTabCommand => _ChangeTabCommand ??= new Command<HomeTab>(ExecuteChangeTabCommand);
    void ExecuteChangeTabCommand(HomeTab selectedTab)
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

    ICommand _CreateStoryCommand;
    public ICommand CreateStoryCommand => _CreateStoryCommand ??= new Command(ExecuteCreateStoryCommand);
    void ExecuteCreateStoryCommand()
    {

    }
}

