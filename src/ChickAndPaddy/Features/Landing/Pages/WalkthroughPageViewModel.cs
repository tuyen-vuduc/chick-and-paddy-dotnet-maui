using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChickAndPaddy
{
    public class WalkthroughPageViewModel : NavigationAwareBaseViewModel
    {
        private readonly ILandingService landingService;

        public WalkthroughPageViewModel(
            ILandingService landingService,
            IAppNavigator appNavigator)
            : base(appNavigator)
        {
            this.landingService = landingService;
        }

        public ObservableCollection<WalkthroughItemModel> Items { get; set; }
        public int ItemPosition { get; set; }
        public bool AllowsToGoback => ItemPosition > 0;
        public bool AllowsToContinue => ItemPosition < Items?.Count - 1;
        public bool AllowsToStart => ItemPosition == Items?.Count - 1;
        public bool AllowsToSkip => AllowsToContinue;

        protected async override void OnInit(IDictionary<string, object> query)
        {
            base.OnInit(query);

            var items = await landingService.GetWalkthroughItemsAsync();

            Items = new ObservableCollection<WalkthroughItemModel>(items);
        }

        ICommand _MoveCommand;
        public ICommand MoveCommand => _MoveCommand ??= new Command<bool>(ExecuteMoveCommand);
        private void ExecuteMoveCommand(bool goback)
        {
            ItemPosition += goback ?  -1 : 1;
        }

        ICommand _StartCommand;
        public ICommand StartCommand => _StartCommand ??= new Command(ExecuteStartCommand);
        private void ExecuteStartCommand()
        {
            SignInAsync();
        }

        ICommand _SkipCommand;
        public ICommand SkipCommand => _SkipCommand ??= new Command(ExecuteSkipCommand);
        private void ExecuteSkipCommand()
        {
            SignInAsync();
        }

        Task SignInAsync() => AppNavigator.NavigateAsync(AppRoutes.SignIn);
    }
}

