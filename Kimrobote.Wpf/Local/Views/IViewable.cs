using System.ComponentModel;
using System.Windows;

namespace Kimrobote.Wpf.Local.Views;

public interface IViewable
{
    FrameworkElement View { get; }
    INotifyPropertyChanged ViewModel { get; }
}
