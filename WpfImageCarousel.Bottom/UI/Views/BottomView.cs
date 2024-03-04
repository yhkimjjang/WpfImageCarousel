using KimRobote.Wpf.Local.Units;
using System.Windows;

namespace WpfImageCarousel.Bottom.UI.Views;

public class BottomView : KimRoboteContent
{
    static BottomView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BottomView), new FrameworkPropertyMetadata(typeof(BottomView)));
    }
}
