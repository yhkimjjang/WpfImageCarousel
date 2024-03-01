using KimRobote.Wpf.Local.Units;
using System.Windows;

namespace WpfImageCarousel.Main.UI.Views;

public class WpfImageCarouselMainView : KimRoboteContent
{
    static WpfImageCarouselMainView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(WpfImageCarouselMainView), new FrameworkPropertyMetadata(typeof(WpfImageCarouselMainView)));
    }
}
