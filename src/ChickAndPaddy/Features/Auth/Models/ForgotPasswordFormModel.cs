namespace ChickAndPaddy;

public partial class ForgotPasswordFormModel : BaseFormModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PhoneNumberValid), nameof(PhoneNumberInvalidMessage))]
    [Required(ErrorMessage = "Your phone number is required to recover your password.")]
    [Phone(ErrorMessage = "You have enter an invalid phone number.")]
    string phoneNumber;

    public bool PhoneNumberValid => GetErrors(nameof(PhoneNumber)).Any() == false;
    public string PhoneNumberInvalidMessage => GetErrors(nameof(PhoneNumber)).FirstOrDefault()?.ErrorMessage;

    partial void OnPhoneNumberChanging(string value)
    {
        ValidateProperty(value, nameof(PhoneNumber));
    }

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(PhoneNumber),
        nameof(PhoneNumberValid),
        nameof(PhoneNumberInvalidMessage),
    };
}

