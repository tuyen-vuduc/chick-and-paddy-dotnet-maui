namespace ChickAndPaddy;

public partial class SignInFormModel : BaseFormModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [NotifyPropertyChangedFor(nameof(UserNameErrors))]
    [NotifyDataErrorInfo]
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
    [NotifyPropertyChangedFor(nameof(PasswordErrors))]
    [NotifyDataErrorInfo]
    string password;

    public IEnumerable<ValidationResult> UserNameErrors => GetErrors(nameof(UserName));
    public IEnumerable<ValidationResult> PasswordErrors => GetErrors(nameof(Password));

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(UserName),
        nameof(UserNameErrors),
        nameof(Password),
        nameof(PasswordErrors),
    };
}

