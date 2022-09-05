namespace ChickAndPaddy;

public partial class StoryView : ContentView
{
    public StoryView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty MoreCommandProperty = BindableProperty.Create(
        nameof(MoreCommand),
        typeof(ICommand),
        typeof(StoryView),
        default,
        BindingMode.OneWay
    );
    public ICommand MoreCommand
    {
        get => (ICommand)GetValue(MoreCommandProperty);
        set => SetValue(MoreCommandProperty, value);
    }

    public static readonly BindableProperty ReplyCommandProperty = BindableProperty.Create(
        nameof(ReplyCommand),
        typeof(ICommand),
        typeof(StoryView),
        default,
        BindingMode.OneWay
    );
    public ICommand ReplyCommand
    {
        get => (ICommand)GetValue(ReplyCommandProperty);
        set => SetValue(ReplyCommandProperty, value);
    }
}
