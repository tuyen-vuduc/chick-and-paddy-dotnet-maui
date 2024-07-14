namespace ChickAndPaddy
{
    public partial class WalkthroughPageViewModel(
            ILandingService landingService,
            IAppNavigator appNavigator) : NavigationAwareBaseViewModel(appNavigator)
    {
        private readonly ILandingService landingService = landingService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AllowsToContinue))]
        [NotifyPropertyChangedFor(nameof(AllowsToStart))]
        [NotifyPropertyChangedFor(nameof(AllowsToSkip))]
        ObservableCollection<WalkthroughItemModel> items;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AllowsToGoback))]
        [NotifyPropertyChangedFor(nameof(AllowsToContinue))]
        [NotifyPropertyChangedFor(nameof(AllowsToStart))]
        [NotifyPropertyChangedFor(nameof(AllowsToSkip))]
        int itemPosition;

        public bool AllowsToGoback => itemPosition > 0;
        public bool AllowsToContinue => itemPosition < items?.Count - 1;
        public bool AllowsToStart => itemPosition == items?.Count - 1;
        public bool AllowsToSkip => AllowsToContinue;

        protected async override void OnInit(IDictionary<string, object> query)
        {
            base.OnInit(query);

            var items = await landingService.GetWalkthroughItemsAsync();

            Items = new ObservableCollection<WalkthroughItemModel>(items);
        }

        [RelayCommand]
        void Move(bool goback) => ItemPosition += goback ? -1 : 1;

        [RelayCommand]
        Task StartAsync() => SignInAsync();

        [RelayCommand]
        Task SkipAsync() => SignInAsync();

        Task SignInAsync() => AppNavigator.NavigateAsync(AppRoutes.SignIn);
    }
}

