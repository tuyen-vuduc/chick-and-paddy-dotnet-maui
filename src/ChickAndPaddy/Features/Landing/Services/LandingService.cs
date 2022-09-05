namespace ChickAndPaddy;

[ExcludeFromCodeCoverage]
public class LandingService : ILandingService
{
    public Task<IEnumerable<WalkthroughItemModel>> GetWalkthroughItemsAsync()
    {
        return Task.FromResult(GenerateItems());
    }

    static IEnumerable<WalkthroughItemModel> GenerateItems()
    {
        return new[]
        {
                new WalkthroughItemModel
                {
                    Title = "Chào mừng bạn đến với Chick & Paddy",
                    Subtitle = "CAP (Chick & Paddy) là công cụ thông mình hỗ trợ các cặp đôi sáng tạo, lưu giữ và quản lý những khoảnh khắc bên nhau.",
                    Image = "walkthrough_01.png",
                },
                new WalkthroughItemModel
                {
                    Title = "Sáng tạo bài viết, hình ảnh, video",
                    Subtitle = "Bạn có thể dễ dàng tạo bài viết, album, video lưu giữ những kỷ niệm của 2 người.",
                    Image = "walkthrough_02.png",
                    ImageMargin = new Thickness(Dimens.SpacingXxl, Dimens.SpacingMd),
                },
                new WalkthroughItemModel
                {
                    Title = "Trò chuyện riêng tư, bảo mật tuyệt đối",
                    Subtitle = "Bạn chỉ trò chuyện với một người duy nhất trong CAP, riêng tư, thoải mái, bảo mật.",
                    Image = "walkthrough_03.png",
                },
                new WalkthroughItemModel
                {
                    Title = "Kho couple game với hơn 1000 trò chơi",
                    Subtitle = "Chúng tôi có kho dữ liệu khổng lồ với 1000+ mini game đa thể loại giúp 2 bạn tăng tương tác với nhau.",
                    Image = "walkthrough_04.png",
                    ImageMargin = new Thickness(Dimens.SpacingXxl, Dimens.SpacingMd),
                },
            };
    }
}

