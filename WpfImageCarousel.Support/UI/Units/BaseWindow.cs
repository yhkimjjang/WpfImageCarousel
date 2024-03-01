using Kimrobote.Wpf.Local.Views;
using System.Windows;

namespace WpfImageCarousel.Support.UI.Units;

public class BaseWindow : KimRoboteWindow
{
    static BaseWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseWindow), new FrameworkPropertyMetadata(typeof(BaseWindow)));
    }
}
