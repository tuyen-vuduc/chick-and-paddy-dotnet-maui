using System.Windows.Input;

namespace ChickAndPaddy;

public abstract class BaseViewModel : BaseModel
{
    protected IAppNavigator AppNavigator { get; }

    protected BaseViewModel(IAppNavigator appNavigator)
    {
        AppNavigator = appNavigator;
    }

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once VirtualMemberNeverOverridden.Global
    public virtual Task OnAppearingAsync()
    {
        System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnAppearingAsync)}");

        return Task.CompletedTask;
    }

    // ReSharper disable once UnusedParameter.Global
    // ReSharper disable once UnusedMethodReturnValue.Global
    // ReSharper disable once VirtualMemberNeverOverridden.Global
    public virtual Task OnDisappearingAsync()
    {
        System.Diagnostics.Debug.WriteLine($"{GetType().Name}.{nameof(OnDisappearingAsync)}");

        return Task.CompletedTask;
    }

    ICommand _BackCommand;
    public ICommand BackCommand => _BackCommand ??= new Command(ExecuteBackCommand);
    void ExecuteBackCommand() => AppNavigator.GoBackAsync();
}
