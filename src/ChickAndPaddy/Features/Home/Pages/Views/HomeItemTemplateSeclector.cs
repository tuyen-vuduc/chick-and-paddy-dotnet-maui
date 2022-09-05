namespace ChickAndPaddy;

public class HomeItemTemplateSeclector : DataTemplateSelector
{
    public DataTemplate Expanded { get; set; }
    public DataTemplate Collapsed { get; set; }
    public DataTemplate Story { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var homeItemType = HomeItemTypeHelper.GetHomeItemType(container);

        switch (homeItemType)
        {
            case HomeItemType.CoupleMilestoneCollapsed:
                return Collapsed;
            case HomeItemType.Story:
                return Story;
        }

        return Expanded;
    }
}

