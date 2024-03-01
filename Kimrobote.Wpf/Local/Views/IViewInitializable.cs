using Kimrobote.Wpf.Local.Views;

namespace KimRobote.Wpf.Local.Views
{
    public interface IViewInitializable
    {
        void OnViewWired(IViewable view);
    }
}
