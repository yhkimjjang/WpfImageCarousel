using Prism.Mvvm;

namespace KimRobote.Wpf.Local.Application;

public abstract class KimRoboteViewModelLocator
{
    /// <summary>
    /// WpfKioskViewModelCollection에 등록되어 있는 View와 ViewModel을
    /// <br/>ViewModelLocationProvider로 통해 종속성 주입화 시킴
    /// </summary>
    public void Publish()
    {
        var collection = new KimRoboteViewModelCollection();
        Match(collection);

        foreach (var item in collection.ViewModelCollection)
        {
            ViewModelLocationProvider.Register(item.Key, item.Value);
        }
    }

    /// <summary>
    /// WpfKioskViewModelCollection에 필요한 View와 ViewModel을 등록함
    /// </summary>
    /// <param name="collection"></param>
    protected abstract void Match(KimRoboteViewModelCollection collection);
}
