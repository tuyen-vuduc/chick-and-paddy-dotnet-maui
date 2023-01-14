namespace ChickAndPaddy;

public class BasePopup : BasePage
{
    public BasePopup()
    {
        Shell.SetPresentationMode(this, PresentationMode.Modal);
    }
}
