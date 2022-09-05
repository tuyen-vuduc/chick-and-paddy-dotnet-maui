namespace ChickAndPaddy;

public class NewsFeedModel : BaseModel
{
    public Guid Id { get; set; }

    public string AvatarUrl { get; set; }

    public string Title { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Location { get; set; }

    public string Content { get; set; }

    public IEnumerable<PhotoModel> Photos { get; set; }
}

public class PhotoModel
{
    public string Url { get; set; }
}

