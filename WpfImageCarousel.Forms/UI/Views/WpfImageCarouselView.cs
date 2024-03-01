using System.Windows;
using WpfImageCarousel.Support.UI.Units;

namespace WpfImageCarousel.Forms.UI.Views
{
    public class WpfImageCarouselView : BaseWindow
    {
        static WpfImageCarouselView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WpfImageCarouselView), new FrameworkPropertyMetadata(typeof(WpfImageCarouselView)));
        }
    }
}
