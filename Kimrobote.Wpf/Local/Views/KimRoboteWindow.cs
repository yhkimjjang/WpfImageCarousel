using KimRobote.Wpf.Local.Application;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Kimrobote.Wpf.Local.Views;

public class KimRoboteWindow : Window, IViewable
{
    private readonly AutoWireManager _autoWireManager;

    public FrameworkElement View => _autoWireManager.GetView();
    public INotifyPropertyChanged ViewModel => _autoWireManager.GetDataContext();

    public KimRoboteWindow()
    {
        _autoWireManager = new AutoWireManager();
        _autoWireManager.InitializeAutoWire(this);
    }

    public KimRoboteWindow AddChild(FrameworkElement fe)
    {
        Content = fe;
        return this;
    }

    public KimRoboteWindow CenterAlignContent()
    {
        if (Content is FrameworkElement content)
        {
            content.HorizontalAlignment = HorizontalAlignment.Center;
            content.VerticalAlignment = VerticalAlignment.Center;
        }
        return this;
    }

    public KimRoboteWindow ApplyThemeColors(string background, string borderBrush, string foreground)
    {
        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(background));
        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(borderBrush));
        Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(foreground));
        return this;
    }
}
