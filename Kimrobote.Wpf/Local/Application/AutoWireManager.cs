using Kimrobote.Wpf.Local.Views;
using KimRobote.Wpf.Local.Views;
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;

namespace KimRobote.Wpf.Local.Application;

internal class AutoWireManager
{
    private FrameworkElement _view;

    internal void InitializeAutoWire(FrameworkElement view)
    {
        _view = view;
        ViewModelLocationProvider.AutoWireViewModelChanged(view, AutoWireViewModelChanged);
    }

    public virtual void AutoWireViewModelChanged(object view, object dataContext)
    {
        _view.DataContext = dataContext;

        if (dataContext is IViewInitializable viewModel)
        {
            viewModel.OnViewWired(view as IViewable);
        }

        if (dataContext is IViewLoadable && view is FrameworkElement frameworkElement)
        {
            frameworkElement.Loaded += Content_Loaded;
        }
    }

    private void Content_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement fe && fe.DataContext is IViewLoadable vm)
        {
            fe.Loaded -= Content_Loaded;
            vm.OnLoaded(fe as IViewable);
        }
    }

    internal FrameworkElement GetView()
    {
        return _view;
    }

    internal INotifyPropertyChanged GetDataContext()
    {
        return _view.DataContext is INotifyPropertyChanged vm ? vm : null;
    }
}
