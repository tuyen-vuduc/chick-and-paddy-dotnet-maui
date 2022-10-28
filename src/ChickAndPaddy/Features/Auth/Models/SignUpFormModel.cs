namespace ChickAndPaddy;

public partial class SignUpFormModel : BaseFormModel
{
    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your full name")]
    [NotifyPropertyChangedFor(nameof(FullNameValid), nameof(FullNameInvalidMessage))]
    string fullName;

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please a valid your phone number")]
    [NotifyPropertyChangedFor(nameof(PhoneNumberValid), nameof(PhoneNumberInvalidMessage))]
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
    [NotifyPropertyChangedFor(nameof(PasswordValid), nameof(PasswordInvalidMessage))]
    string password;

    [ObservableProperty]
    [Required(ErrorMessage = "Please enter a confirm password")]
    [FieldCompare(nameof(Password))]
    [NotifyPropertyChangedFor(nameof(ConfirmPasswordValid), nameof(ConfirmPasswordInvalidMessage))]
    string confirmPassword;

    public bool FullNameValid => GetErrors(nameof(FullName)).Any() == false;
    public string FullNameInvalidMessage => GetErrors(nameof(FullName)).FirstOrDefault()?.ErrorMessage;

    partial void OnFullNameChanging(string value)
    {
        ValidateProperty(value, nameof(FullName));
    }

    public bool PhoneNumberValid => GetErrors(nameof(PhoneNumber)).Any() == false;
    public string PhoneNumberInvalidMessage => GetErrors(nameof(PhoneNumber)).FirstOrDefault()?.ErrorMessage;

    partial void OnPhoneNumberChanging(string value)
    {
        ValidateProperty(value, nameof(PhoneNumber));
    }

    public bool PasswordValid => GetErrors(nameof(Password)).Any() == false;
    public string PasswordInvalidMessage => GetErrors(nameof(Password)).FirstOrDefault()?.ErrorMessage;

    partial void OnPasswordChanging(string value)
    {
        ValidateProperty(value, nameof(Password));
    }

    public bool ConfirmPasswordValid => GetErrors(nameof(ConfirmPassword)).Any() == false;
    public string ConfirmPasswordInvalidMessage => GetErrors(nameof(ConfirmPassword)).FirstOrDefault()?.ErrorMessage;

    partial void OnConfirmPasswordChanging(string value)
    {
        ValidateProperty(value, nameof(ConfirmPassword));
    }

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(FullName),
        nameof(FullNameValid),
        nameof(FullNameInvalidMessage),
        nameof(PhoneNumber),
        nameof(PhoneNumberValid),
        nameof(PhoneNumberInvalidMessage),
        nameof(Password),
        nameof(PasswordValid),
        nameof(PasswordInvalidMessage),
        nameof(ConfirmPassword),
        nameof(ConfirmPasswordValid),
        nameof(ConfirmPasswordInvalidMessage),
    };
}

