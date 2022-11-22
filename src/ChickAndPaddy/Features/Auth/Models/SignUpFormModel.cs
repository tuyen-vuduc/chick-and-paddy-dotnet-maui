namespace ChickAndPaddy;

public partial class SignUpFormModel : BaseFormModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your full name")]
    [NotifyPropertyChangedFor(nameof(FullNameErrors))]
    [NotifyDataErrorInfo]
    string fullName;

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please a valid your phone number")]
    [NotifyPropertyChangedFor(nameof(PhoneNumberErrors))]
    [NotifyDataErrorInfo]
    string phoneNumber;

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

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter a confirm password")]
    [FieldCompare(nameof(Password))]
    [NotifyPropertyChangedFor(nameof(ConfirmPasswordErrors))]
    [NotifyDataErrorInfo]
    string confirmPassword;

    public IEnumerable<ValidationResult> FullNameErrors => GetErrors(nameof(FullName));
    public IEnumerable<ValidationResult> PhoneNumberErrors => GetErrors(nameof(PhoneNumber));
    public IEnumerable<ValidationResult> PasswordErrors => GetErrors(nameof(Password));
    public IEnumerable<ValidationResult> ConfirmPasswordErrors => GetErrors(nameof(ConfirmPassword));

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(FullName),
        nameof(FullNameErrors),
        nameof(PhoneNumber),
        nameof(PhoneNumberErrors),
        nameof(Password),
        nameof(PasswordErrors),
        nameof(ConfirmPassword),
        nameof(ConfirmPasswordErrors),
    };
}

