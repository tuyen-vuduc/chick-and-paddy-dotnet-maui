using System;
namespace ChickAndPaddy;

public class WalkthroughItemModel : BaseModel
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Image { get; set; }
    public Thickness ImageMargin { get; set; }
}

