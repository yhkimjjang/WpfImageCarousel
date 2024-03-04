using Kimrobote.Wpf.Local.Views;
using Prism.Ioc;
using Prism.Regions;
using WpfImageCarousel.Bottom.UI.Views;
using WpfImageCarousel.Main.UI.Views;
using WpfImageCarousel.Support.Enums;

namespace WpfImageCarousel.Forms.Local.ViewModels;

public class WpfImageCarouselViewViewModel : IViewLoadable
{
    private readonly IContainerProvider _containerProvider;
    private readonly IRegionManager _regionManger;

    public WpfImageCarouselViewViewModel(IContainerProvider containerProvider, IRegionManager regionManger)
    {
        _containerProvider = containerProvider;
        _regionManger = regionManger;
    }

    public void OnLoaded(IViewable view)
    {
        ImportContent<MainView>(RegionNames.MainView.ToString());
        ImportContent<BottomView>(RegionNames.BottomView.ToString());
    }

    private void ImportContent<TViewType>(string regionName)
    {
        IRegion region = _regionManger.Regions[regionName];
        var container = _containerProvider.Resolve<TViewType>();
        if(!region.Views.Contains(container))
        {
            region.Add(container);
        }

        region.Activate(container);
    }
}
