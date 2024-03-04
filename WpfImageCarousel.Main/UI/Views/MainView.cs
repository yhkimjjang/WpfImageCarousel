using KimRobote.Wpf.Local.Units;
using System.Windows;

namespace WpfImageCarousel.Main.UI.Views;

public class MainView : KimRoboteContent
{
    static MainView()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MainView), new FrameworkPropertyMetadata(typeof(MainView)));
    }
}
