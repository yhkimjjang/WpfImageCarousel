using Prism.Ioc;
using Prism.Modularity;
using WpfImageCarousel.Support.Local.Helpers;

namespace WpfImageCarousel.Properties;

public class HelperModules : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterInstance<IImageLoder>(new LocalImageLoader());
        //containerRegistry.RegisterSingleton<IImageLoder, LocalImageLoader>();
        containerRegistry.RegisterSingleton<ImageInfoManager>();
        containerRegistry.Register<RollingTimer>();
    }
}
