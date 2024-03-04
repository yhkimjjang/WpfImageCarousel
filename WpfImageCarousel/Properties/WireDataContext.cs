using KimRobote.Wpf.Local.Application;
using WpfImageCarousel.Forms.Local.ViewModels;
using WpfImageCarousel.Forms.UI.Views;
using WpfImageCarousel.Main.Local.ViewModels;
using WpfImageCarousel.Main.UI.Views;

namespace WpfImageCarousel.Properties;

/// <summary>
/// View와 ViewModel 종속성 연결 기능 수행
/// </summary>
internal class WireDataContext : KimRoboteViewModelLocator
{
    protected override void Match(KimRoboteViewModelCollection collection)
    {
        collection.Register<WpfImageCarouselViewViewModel>(typeof(WpfImageCarouselView));
        collection.Register<MainViewViewModel>(typeof(MainView));
    }
}
