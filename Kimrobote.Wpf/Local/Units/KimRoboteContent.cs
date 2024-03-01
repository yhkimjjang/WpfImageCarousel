using Kimrobote.Wpf.Local.Views;
using KimRobote.Wpf.Local.Application;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace KimRobote.Wpf.Local.Units
{
    public abstract class KimRoboteContent : ContentControl, IViewable
    {
        private readonly AutoWireManager _autoWireManager;

        public FrameworkElement View => _autoWireManager.GetView();
        public INotifyPropertyChanged ViewModel => _autoWireManager.GetDataContext();

        public KimRoboteContent()
        {
            _autoWireManager = new AutoWireManager();
            _autoWireManager.InitializeAutoWire(this);
        }
    }
}
