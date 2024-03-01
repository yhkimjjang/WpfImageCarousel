using Prism.Modularity;
using Prism.Unity;

namespace KimRobote.Wpf.Local.Application;

public abstract class KimRoboteApplication : PrismApplication
{
    private List<IModule> _modules = new List<IModule>();

    /// <summary>
    /// ViewModel을 View에 종속성 주입시킴
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public KimRoboteApplication AddWridDataContext<T>() where T : KimRoboteViewModelLocator, new()
    {
        KimRoboteViewModelLocator locator = new T();
        locator.Publish();
        return this;
    }

    public KimRoboteApplication AddInversionModule<T>() where T : IModule, new()
    {
        IModule module = new T();
        _modules.Add(module);

        return this;
    }
}
