namespace ChickAndPaddy;

public partial class ForgotPasswordFormModel : BaseFormModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PhoneNumberErrors))]
    [Required(ErrorMessage = "Your phone number is required to recover your password.")]
    [Phone(ErrorMessage = "You have entered an invalid phone number.")]
    [NotifyDataErrorInfo]
    string phoneNumber;

    public IEnumerable<ValidationResult> PhoneNumberErrors => GetErrors(nameof(PhoneNumber));

    protected override string[] ValidatableAndSupportPropertyNames => new[]
    {
        nameof(PhoneNumber),
        nameof(PhoneNumberErrors),
    };
}