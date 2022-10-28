namespace ChickAndPaddy;

public partial class SignInFormModel : BaseFormModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [NotifyPropertyChangedFor(nameof(UserNameValid), nameof(UserNameInvalidMessage))]
    string userName;

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter a password")]
    [Password(
        IncludesLower = true,
        IncludesNumber = true,
        IncludesSpecial = true,
        IncludesUpper = true,
        MinimumLength = 6,
        ErrorMessage = "Please enter a strong password: from 8 characters, 1 upper, 1 lower, 1 digit, 1 special character"
    )]
    [NotifyPropertyChangedFor(nameof(PasswordValid), nameof(PasswordInvalidMessage))]
    string password;

    public bool UserNameValid => GetErrors(nameof(UserName)).Any() == false;
    public string UserNameInvalidMessage => GetErrors(nameof(UserName)).FirstOrDefault()?.ErrorMessage;

    partial void OnUserNameChanging(string value)
    {
        ValidateProperty(value, nameof(UserName));
    }

    public bool PasswordValid => GetErrors(nameof(Password)).Any() == false;
    public string PasswordInvalidMessage => GetErrors(nameof(Password)).FirstOrDefault()?.ErrorMessage;

    partial void OnPasswordChanging(string value)
    {
        ValidateProperty(value, nameof(Password));
    }

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(UserName),
        nameof(UserNameValid),
        nameof(UserNameInvalidMessage),
        nameof(Password),
        nameof(PasswordValid),
        nameof(PasswordInvalidMessage),
    };
}

