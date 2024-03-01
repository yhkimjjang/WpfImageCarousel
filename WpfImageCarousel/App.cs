using KimRobote.Wpf.Local.Application;
using Prism.Ioc;
using System.Windows;
using WpfImageCarousel.Forms.UI.Views;

namespace WpfImageCarousel;

internal class App : KimRoboteApplication
{
    protected override Window CreateShell()
    {
        return new WpfImageCarouselView();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
}
